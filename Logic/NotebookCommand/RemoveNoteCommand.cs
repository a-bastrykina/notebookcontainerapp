using System;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class RemoveNoteCommand : INotebookCommand
    {
        private readonly INotebook _notebook;

        public RemoveNoteCommand(INotebook notebook)
        {
            _notebook = notebook;
        }
        
        public void Execute()
        {
            Console.WriteLine("Enter note to remove: ");
            var note = Console.ReadLine();
            var index = _notebook.Notes.FindIndex(n =>  n.ToString().Equals(note) );
            if (index < 0)
            {
                Console.WriteLine("Can't find such note");
                return;
            }
            _notebook.Notes.RemoveAt(index);
        }
    }
}