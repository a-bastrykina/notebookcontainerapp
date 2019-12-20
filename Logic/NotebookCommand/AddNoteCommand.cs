using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using Notebook.NoteFactory;

namespace Notebook
{
    [ContainerElement]
    public class AddNoteCommand : INotebookCommand
    {
        private INotebook _notebook;
        private Dictionary<string, INoteFactory> _noteFactories = new Dictionary<string, INoteFactory>();
        public AddNoteCommand(List<INoteFactory> noteFactories, INotebook notebook)
        {
            _noteFactories = noteFactories.ToDictionary(x => x.TypeName);
//            foreach (var fact in noteFactories)
//            {
//                _noteFactories[fact.TypeName] = fact;
//            }

            _notebook = notebook;
        }

        private void ListAvailableNoteTypes()
        {
            Console.WriteLine("Available note types: ");
            foreach (var fact in _noteFactories)
            {
                Console.WriteLine(fact.Key);
            }
        }
        public void Execute()
        {
            Console.Write("Enter note type: ");
            var noteStr = Console.ReadLine().Trim();
            if (!_noteFactories.ContainsKey(noteStr))
            {
                ListAvailableNoteTypes();
                return;
            }

            Console.WriteLine("Enter note:");
            var content = Console.ReadLine();
            var factory = _noteFactories[noteStr];
            try
            {
                var note = factory.createFromCommandLine(content);
                _notebook.Notes.Add(note);
            }
            catch (Exception)
            {
                Console.WriteLine("Bad note format");
            }
        }
    }
}