using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using JetBrains.Annotations;
using Logic.UserInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notebook
{
    [Attributes.CommonElement]
    public class SerializeNotebookCommand : INotebookCommand
    {
        [NotNull]
        private readonly INotebook _notebook;
        [NotNull]
        private readonly SerializeCommandInput _input;
        public SerializeNotebookCommand([NotNull] INotebook notebook, [NotNull] SerializeCommandInput input)
        {
            _input = input;
            _notebook = notebook;
        }
        
        public void Execute()
        {
            var filePath = _input.GetFileName();
            Debug.Assert(filePath != null, nameof(filePath) + " != null");

            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All, NullValueHandling = NullValueHandling.Ignore
            };
            Debug.Assert(serializer.Converters != null, "serializer.Converters != null");
            serializer.Converters.Add(new JavaScriptDateTimeConverter());


            try
            {
                using var sw = new StreamWriter(filePath);
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, _notebook.Notes);
            }
            catch (Exception)
            {
                _input.ReportProblemsWithSerialization();
            }
        }
    }
}