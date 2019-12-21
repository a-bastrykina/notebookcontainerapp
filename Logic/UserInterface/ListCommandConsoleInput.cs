using System;
using System.Collections.Generic;
using Notebook;

namespace Logic.UserInterface
{
    public class ListCommandConsoleInput : ListCommandInput
    {
        public void ListNotes(List<INote> notes)
        {
            int i = 1;
            foreach (var item in notes)
            {
                Console.WriteLine($"{i}. {item.ToString()}");
                i++;
            }
        }
    }
}