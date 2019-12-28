using System.Collections.Generic;
using Notebook;

namespace Logic.UserInterface
{
    [Attributes.ConsoleElement]
    public interface ListCommandInput
    {
        void ListNotes(List<INote> notes);
    }
}