using Notebook;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = Container.Container.Create<CommandParser>();
            parser.Start();
        }
    }
}