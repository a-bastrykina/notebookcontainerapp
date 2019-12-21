using Attributes;

namespace Logic.UserInterface
{
    [ContainerElement]
    public class ListCommandInputFactory
    {
        public ListCommandInput GetInput()
        {
            return new ListCommandConsoleInput();
        }
    }
}