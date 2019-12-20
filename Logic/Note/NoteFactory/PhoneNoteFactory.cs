using Attributes;

namespace Notebook.NoteFactory
{
    [ContainerElement]
    public class PhoneNoteFactory: INoteFactory
    {
        public string TypeName { get; } = "PhoneNote";

        public INote createFromCommandLine(string content)
        {
            return new PhoneNote(content);
        }
    }
}