using Attributes;

namespace Notebook.NoteFactory
{
    [CommonElement]
    public class StudentNoteFactory : INoteFactory
    {
        public string TypeName { get; } = "StudentNote";

        public INote createFromCommandLine(string content)
        {
            return new StudentNote(content);
        }

        public INote createFromKeyValue(string key, string value)
        {
            return new StudentNote(key, value);
        }
    }
}