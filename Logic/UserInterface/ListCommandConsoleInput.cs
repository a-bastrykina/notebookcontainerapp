using System;
using System.Collections.Generic;
using System.Diagnostics;
using Notebook;

namespace Logic.UserInterface
{
    [Attributes.ConsoleElement]
    public class ListCommandConsoleInput : ListCommandInput
    {
        public void ListNotes(List<INote> notes)
        {
            int i = 1;
            Debug.Assert(notes != null, nameof(notes) + " != null");
            foreach (var item in notes)
            {
                Debug.Assert(item != null, nameof(item) + " != null");
                Console.WriteLine($"{i}. {item.ToString()}");
                i++;
            }
        }
    }
}