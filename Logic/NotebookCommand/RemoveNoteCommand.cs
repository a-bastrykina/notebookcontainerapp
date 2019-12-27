using System;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.CommonElement]
    public class RemoveNoteCommand : INotebookCommand
    {
        private readonly INotebook _notebook;
        private readonly RemoveCommandInput _input;

        public RemoveNoteCommand(INotebook notebook, RemoveCommandInput inputFactory)
        {
            _input = inputFactory;
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