using Notebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attributes;
using Notebook.NoteFactory;

namespace Logic.UserInterface
{
    [ContainerElement]
    class AddCommandConsoleInput : AddCommandInput
    {
        private Dictionary<string, INoteFactory> _noteFactories = new Dictionary<string, INoteFactory>();
        public AddCommandConsoleInput(List<INoteFactory> noteFactories)
        {
            _noteFactories = noteFactories.ToDictionary(x => x.TypeName);
        }
        
        private void ListAvailableNoteTypes()
        {
            Console.WriteLine("Available note types: ");
            foreach (var fact in _noteFactories)
            {
                Console.WriteLine(fact.Key);
            }
        }
        
        public INote GetNote()
        {
            Console.Write("Enter note type: ");
            var noteStr = Console.ReadLine().Trim();
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
                return factory.createFromCommandLine(content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad note format!");
                throw e;
            }
        }

    }
}
