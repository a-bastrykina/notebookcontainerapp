using System;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.ConsoleElement]
    public class ListNotebookCommand: INotebookCommand
    {
        private readonly INotebook _notebook;
        private readonly ListCommandInput _input;
        
        public ListNotebookCommand(INotebook notebook, ListCommandInput input)
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