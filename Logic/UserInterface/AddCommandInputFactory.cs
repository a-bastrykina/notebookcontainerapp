using System.Collections.Generic;
using Attributes;
using Notebook.NoteFactory;

namespace Logic.UserInterface
{
    [ContainerElement]
    public class AddCommandInputFactory
    {
        private readonly List<INoteFactory> _noteFactories;
        public AddCommandInputFactory(List<INoteFactory> noteFactories)
        {
            _noteFactories = noteFactories;
        }
        
        public AddCommandInput GetInput()
        {
            return new AddCommandConsoleInput(_noteFactories);
        }
    }
}