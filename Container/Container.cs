using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Attributes;

namespace Container
{
    public class Container
    {
        private static readonly List<Type> _visitedElements = new List<Type>();
        private static readonly Dictionary<Type, Object> _createdObjects = new Dictionary<Type, object>();
        private static readonly List<Type> _containerElements = new List<Type>();

        public static T Create<T>()
        {
            var assemblies = Assembly.Load("Logic");
            foreach (var cls in assemblies.GetTypes())
            {
                if (Attribute.IsDefined(cls, typeof(ContainerElement)))
                {
                    _containerElements.Add(cls);
                }
            }

            if (!_createdObjects.ContainsKey(typeof(T)))
            {
                Build(typeof(T));
            }

            return (T) _createdObjects[typeof(T)];
        }

        private static void Build(Type type)
        {
            if (!_containerElements.Contains(type))
            {
                throw new ArgumentException($"{type} is not a container element");
            }

            if (_createdObjects.ContainsKey(type)) return;

            Console.WriteLine($"Started {type} build");
            var constructor = type.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();

            if (constructorParams.Length == 0)
            {
                _createdObjects[type] = constructor.Invoke(null);
                return;
            }

            _visitedElements.Add(type);
            foreach (var param in constructorParams)
            {
                if (_visitedElements.Contains(param.ParameterType))
                {
                    throw new ArgumentException("Found cycle dependency");
                }

                if (param.ParameterType.IsInterface)
                {
                    var impl = GetFirstInterfaceRealization(param.ParameterType);
                    Build(impl);
                }
                
                if (param.ParameterType.IsGenericType &&
                    param.ParameterType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listInstance = (IList) Activator.CreateInstance(param.ParameterType);
                    GetInterfaceRealizationsList(param.ParameterType).ForEach(t =>
                    {
                        Build(t);
                        listInstance.Add(_createdObjects[t]);
                        _createdObjects.Remove(t);
                    });
                    _createdObjects[param.ParameterType] = listInstance;
                }
                else
                {
                    Build(param.ParameterType);
                }
            }

            _visitedElements.Clear();
            List<Object> parameterInstances = new List<object>();
            foreach (var param in constructorParams)
            {
                parameterInstances.Add(_createdObjects[param.ParameterType]);
            }

            _createdObjects[type] = constructor.Invoke(parameterInstances.ToArray());
        }

        private static List<Type> GetInterfaceRealizationsList(Type listType)
        {
            var interfaceType = listType.GenericTypeArguments[0];
            var implTypes = new List<Type>();
            foreach (var type in _containerElements)
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
            foreach (var type in _containerElements)
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