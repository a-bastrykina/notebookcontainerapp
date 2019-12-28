using System;
using JetBrains.Annotations;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.CommonElement]
    public class RemoveNoteCommand : INotebookCommand
    {
        [NotNull]
        private readonly INotebook _notebook;
        [NotNull]
        private readonly RemoveCommandInput _input;

        public RemoveNoteCommand([NotNull] INotebook notebook, [NotNull] RemoveCommandInput inputFactory)
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