using Notebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Notebook.NoteFactory;

namespace Logic.UserInterface
{
    [Attributes.ConsoleElement]
    class AddCommandConsoleInput : AddCommandInput
    {
        private Dictionary<string, INoteFactory> _noteFactories;
        public AddCommandConsoleInput([NotNull] List<INoteFactory> noteFactories)
        {
            _noteFactories = noteFactories.ToDictionary(x => x.TypeName);
        }
        
        private void ListAvailableNoteTypes()
        {
            Console.WriteLine("Available note types: ");
            Debug.Assert(_noteFactories != null, nameof(_noteFactories) + " != null");
            foreach (var fact in _noteFactories)
            {
                Console.WriteLine(fact.Key);
            }
        }
        
        public INote GetNote()
        {
            Console.Write("Enter note type: ");
            var noteStr = Console.ReadLine()?.Trim();
            Debug.Assert(_noteFactories != null, nameof(_noteFactories) + " != null");
            Debug.Assert(noteStr != null, nameof(noteStr) + " != null");
            if (!_noteFactories.ContainsKey(noteStr))
            {
                ListAvailableNoteTypes();
                throw new KeyNotFoundException();
            }

            Console.WriteLine("Enter note:");
            var content = Console.ReadLine();
            var factory = _noteFactories[noteStr];
            try
            {
                Debug.Assert(factory != null, nameof(factory) + " != null");
                return factory.createFromCommandLine(content);
            }
            catch (Exception)
            {
                Console.WriteLine("Bad note format!");
                throw;
            }
        }

    }
}
