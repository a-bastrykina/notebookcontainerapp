using Attributes;

namespace Logic.UserInterface
{
    [ContainerElement]
    public class SerializeCommandInputFactory
    {
        public SerializeCommandInput GetInput()
        {
            return new SerializeCommandConsoleInput();
        }
    }
}