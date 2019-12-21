using Attributes;

namespace Logic.UserInterface
{
    [ContainerElement]
    public class DeserializeCommandInputFactory
    {
        public DeserializeCommandInput GetInput()
        {
            return new DeserializeCommandConsoleInput();
        }
    }
}