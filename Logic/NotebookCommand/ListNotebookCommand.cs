using System;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class ListNotebookCommand: INotebookCommand
    {
        private INotebook _notebook;
        
        public ListNotebookCommand(INotebook notebook)
        {
            _notebook = notebook;
        }
        
        public void Execute()
        {
            int i = 1;
            foreach (var item in _notebook.Notes)
            {
                Console.WriteLine($"{i}. {item.ToString()}");
                i++;
            }
        }
    }
}