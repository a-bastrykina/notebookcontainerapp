using System.Collections.Generic;
using Notebook;

namespace Logic.UserInterface
{
    [Attributes.CommonElement]
    public interface ListCommandInput
    {
        void ListNotes(List<INote> notes);
    }
}