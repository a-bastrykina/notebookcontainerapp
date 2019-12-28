using System;
using JetBrains.Annotations;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.ConsoleElement]
    public class ListNotebookCommand: INotebookCommand
    {
        [NotNull]
        private readonly INotebook _notebook;
        [NotNull]
        private readonly ListCommandInput _input;
        
        public ListNotebookCommand([NotNull] INotebook notebook, [NotNull] ListCommandInput input)
        {
            _input = input;
            _notebook = notebook;
        }
        
        public void Execute()
        {
            _input.ListNotes(_notebook.Notes);
        }
    }
}