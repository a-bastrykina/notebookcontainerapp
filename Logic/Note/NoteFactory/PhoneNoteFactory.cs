using Attributes;

namespace Notebook.NoteFactory
{
    [CommonElement]
    public class PhoneNoteFactory: INoteFactory
    {
        public string TypeName { get; } = "PhoneNote";

        public INote createFromCommandLine(string content)
        {
            return new PhoneNote(content);
        }

        public INote createFromKeyValue(string key, string value)
        {
            return new PhoneNote(key, value);
        }
    }
}