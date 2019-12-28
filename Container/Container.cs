using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Attributes;
using JetBrains.Annotations;

namespace Container
{
    public class Container
    {
        [NotNull]
        private static readonly List<Type> VisitedElements = new List<Type>();
        [NotNull]
        private static readonly Dictionary<Type, object> CreatedObjects = new Dictionary<Type, object>();
        [NotNull]
        private static readonly List<Type> ContainerElements = new List<Type>();

        public static T Create<T, TBuildAttr>()
        {
            var types = Assembly.Load("Logic")?.GetTypes().ToList();
            Debug.Assert(types != null, nameof(types) + " != null");
//            types.AddRange(Assembly.Load("NotebookUI")?.GetTypes());
            foreach (var cls in types)
            {
                if (Attribute.IsDefined(cls, typeof(CommonElement)) || Attribute.IsDefined(cls, typeof(TBuildAttr)))
                {
                    ContainerElements.Add(cls);
                }
            }

            if (!CreatedObjects.ContainsKey(typeof(T)))
            {
                Build(typeof(T));
            }

            return (T) CreatedObjects[typeof(T)];
        }

        private static void Build(Type type)
        {
            if (!ContainerElements.Contains(type))
            {
                throw new ArgumentException($"{type} is not a container element");
            }

            Debug.Assert(type != null, nameof(type) + " != null");
            if (CreatedObjects.ContainsKey(type)) return;

            Console.WriteLine($"Started {type} build");
            var constructor = type.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();

            if (constructorParams.Length == 0)
            {
                CreatedObjects[type] = constructor.Invoke(null);
                return;
            }

            VisitedElements.Add(type);
            foreach (var param in constructorParams)
            {
                if (VisitedElements.Contains(param.ParameterType))
                {
                    throw new ArgumentException("Found cycle dependency");
                }

                if (param.ParameterType.IsInterface)
                {
                    var impl = GetFirstInterfaceRealization(param.ParameterType);
                    Build(impl);
                    Debug.Assert(impl != null, nameof(impl) + " != null");
                    CreatedObjects[param.ParameterType] = CreatedObjects[impl];
                    CreatedObjects.Remove(impl);
                    continue;
                }
                
                if (param.ParameterType.IsGenericType &&
                    param.ParameterType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listInstance = (IList) Activator.CreateInstance(param.ParameterType);
                    GetInterfaceRealizationsList(param.ParameterType)
                        ?.ForEach(t =>
                    {
                        Build(t);
                        Debug.Assert(t != null, nameof(t) + " != null");
                        listInstance.Add(CreatedObjects[t]);
                        CreatedObjects.Remove(t);
                    });
                    CreatedObjects[param.ParameterType] = listInstance;
                }
                else
                {
//                    if (param.ParameterType.IsInterface)
//                    {
//                        var impl = GetFirstInterfaceRealization(param.ParameterType);
//                        Build(impl);
//                    }
//                    else
//                    {
                        Build(param.ParameterType);
//                    }
                }
            }

            VisitedElements.Clear();
            List<Object> parameterInstances = new List<object>();
            foreach (var param in constructorParams)
            {
                parameterInstances.Add(CreatedObjects[param.ParameterType]);
            }

            CreatedObjects[type] = constructor.Invoke(parameterInstances.ToArray());
        }

        private static List<Type> GetInterfaceRealizationsList([NotNull] Type listType)
        {
            Debug.Assert(listType.GenericTypeArguments != null, "listType.GenericTypeArguments != null");
            var interfaceType = listType.GenericTypeArguments[0];
            var implTypes = new List<Type>();
            foreach (var type in ContainerElements)
            {
                if (type.GetInterfaces().Contains(interfaceType))
                {
                    implTypes.Add(type);
                }
            }

            return implTypes;
        }

        private static Type GetFirstInterfaceRealization(Type interfaceType)
        {
            foreach (var type in ContainerElements)
            {
                if (type.GetInterfaces().Contains(interfaceType))
                {
                    return type;
                }
            }
            throw new ArgumentException("No interface realizations found in container elements");
        }
    }
}