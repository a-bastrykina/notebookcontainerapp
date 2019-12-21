using System;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class RemoveNoteCommand : INotebookCommand
    {
        private INotebook _notebook;
        private RemoveCommandInput _input;

        public RemoveNoteCommand(INotebook notebook, RemoveCommandInputFactory inputFactory)
        {
            _input = inputFactory.GetInput();
            _notebook = notebook;
        }
        
        public void Execute()
        {
            var index = _input.GetRemoveNoteIndex();
            if (index < 0 || index >= _notebook.Notes.Count)
            {
                _input.ReportInvalidIndex();
                return;
            }
            _notebook.Notes.RemoveAt(index);
        }
    }
}