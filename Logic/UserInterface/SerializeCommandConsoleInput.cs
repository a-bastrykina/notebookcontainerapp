using System;

namespace Logic.UserInterface
{
    public class SerializeCommandConsoleInput : SerializeCommandInput
    {
        public string GetFileName()
        {
            Console.WriteLine("Enter path to save notebook: ");
            return Console.ReadLine();
        }

        public void ReportProblemsWithSerialization()
        {
            Console.WriteLine("Problems with serialization");
        }
    }
}