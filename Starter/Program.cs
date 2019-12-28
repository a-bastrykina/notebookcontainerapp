using System.Diagnostics;
using Notebook;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = Container.Container.Create<CommandParser, Attributes.ConsoleElement>();
            Debug.Assert(parser != null, nameof(parser) + " != null");
            parser.Start();
        }
    }
}