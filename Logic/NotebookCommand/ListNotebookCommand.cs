using System;
using Logic.UserInterface;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class ListNotebookCommand: INotebookCommand
    {
        private INotebook _notebook;
        private ListCommandInput _input;
        
        public ListNotebookCommand(INotebook notebook, ListCommandInputFactory inputFactory)
        {
            _input = inputFactory.GetInput();
            _notebook = notebook;
        }
        
        public void Execute()
        {
            _input.ListNotes(_notebook.Notes);
        }
    }
}