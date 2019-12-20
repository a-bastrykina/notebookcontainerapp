using System;
using System.IO;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class SerializeNotebookCommand : INotebookCommand
    {
        private INotebook _notebook;
        public SerializeNotebookCommand(INotebook notebook)
        {
            _notebook = notebook;
        }
        
        public void Execute()
        {
            Console.WriteLine("Enter path to save notebook: ");
            var filePath = Console.ReadLine();
            
            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.All;
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            
            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, _notebook.Notes);
            }
        }
    }
}