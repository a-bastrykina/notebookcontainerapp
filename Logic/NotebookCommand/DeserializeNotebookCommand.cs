using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class DeserializeNotebookCommand : INotebookCommand
    {
        private INotebook _notebook;
        public DeserializeNotebookCommand(INotebook notebook)
        {
            _notebook = notebook;
        }
        
        public void Execute()
        {
            Console.Write("Enter path to load notebook: ");
            var filePath = Console.ReadLine();
            using (var sr = new StreamReader(filePath))
            {
                var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                var serialized = sr.ReadToEnd();
                var deserializedNotebook = JsonConvert.DeserializeObject<List<INote>>(serialized, settings);
                _notebook.Notes = deserializedNotebook;
            }
        }
    }
}