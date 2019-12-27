using Notebook;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = Container.Container.Create<CommandParser, Attributes.ConsoleElement>();
            parser.Start();
        }
    }
}