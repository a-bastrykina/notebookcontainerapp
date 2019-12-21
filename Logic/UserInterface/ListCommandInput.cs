using System.Collections.Generic;
using Notebook;

namespace Logic.UserInterface
{
    public interface ListCommandInput
    {
        void ListNotes(List<INote> notes);
    }
}