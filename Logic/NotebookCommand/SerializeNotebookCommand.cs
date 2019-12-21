using System;
using System.IO;
using System.Reflection.Metadata;
using Logic.UserInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class SerializeNotebookCommand : INotebookCommand
    {
        private INotebook _notebook;
        private SerializeCommandInput _input;
        public SerializeNotebookCommand(INotebook notebook, SerializeCommandInputFactory inputFactory)
        {
            _input = inputFactory.GetInput();
            _notebook = notebook;
        }
        
        public void Execute()
        {
            var filePath = _input.GetFileName();
            
            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.All;
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Converters.Add(new JavaScriptDateTimeConverter());


            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, _notebook.Notes);
                }
            }
            catch (Exception)
            {
                _input.ReportProblemsWithSerialization();
            }
        }
    }
}