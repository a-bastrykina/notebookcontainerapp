using System;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class HelloWorld: INotebookCommand
    {
        public void Execute()
        {
            Console.WriteLine("Hello world");
        }
    }
}