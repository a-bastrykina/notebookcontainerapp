using Attributes;

namespace Logic.UserInterface
{
    [ContainerElement]
    public class RemoveCommandInputFactory
    {
        public RemoveCommandInput GetInput()
        {
            return new RemoveCommandConsoleInput();
        }
    }
}