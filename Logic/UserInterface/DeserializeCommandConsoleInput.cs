using System;

namespace Logic.UserInterface
{
    [Attributes.ConsoleElement]
    public class DeserializeCommandConsoleInput : DeserializeCommandInput
    {
        public string GetFileName()
        {
            Console.Write("Enter path to load notebook: ");
            return Console.ReadLine();
        }

        public void ReportProblemsWithDeserialization()
        {
            Console.WriteLine("Problems with deserialization");
        }
    }
}