using System;

namespace Logic.UserInterface
{
    [Attributes.ConsoleElement]
    public class RemoveCommandConsoleInput : RemoveCommandInput
    {
        public int GetRemoveNoteIndex()
        {
            Console.WriteLine("Enter note to remove: ");
            return Int32.Parse(Console.ReadLine());
        }

        public void ReportInvalidIndex()
        {
            Console.WriteLine("Can't find such note");
        }
    }
}