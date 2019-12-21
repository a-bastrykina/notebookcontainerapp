using System;
using System.Collections.Generic;
using System.IO;
using Logic.UserInterface;
using Newtonsoft.Json;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class DeserializeNotebookCommand : INotebookCommand
    {
        private readonly INotebook _notebook;
        private readonly DeserializeCommandInput _input;
        public DeserializeNotebookCommand(INotebook notebook, DeserializeCommandInputFactory inputFactory)
        {
            _input = inputFactory.GetInput();
            _notebook = notebook;
        }
        
        public void Execute()
        {
            var filePath = _input.GetFileName();
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                    var serialized = sr.ReadToEnd();
                    var deserializedNotebook = JsonConvert.DeserializeObject<List<INote>>(serialized, settings);
                    _notebook.Notes = deserializedNotebook;
                }
            }
            catch (Exception)
            {
                _input.ReportProblemsWithDeserialization();
            }
        }
    }
}