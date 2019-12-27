using System;
using System.IO;
using System.Reflection.Metadata;
using Logic.UserInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notebook
{
    [Attributes.CommonElement]
    public class SerializeNotebookCommand : INotebookCommand
    {
        private readonly INotebook _notebook;
        private readonly SerializeCommandInput _input;
        public SerializeNotebookCommand(INotebook notebook, SerializeCommandInput input)
        {
            _input = input;
            _notebook = notebook;
        }
        
        public void Execute()
        {
            var filePath = _input.GetFileName();

            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All, NullValueHandling = NullValueHandling.Ignore
            };
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