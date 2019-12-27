namespace Notebook.NoteFactory
{
    [Attributes.CommonElement]
    public interface INoteFactory
    {
        string TypeName { get; }
        INote createFromCommandLine(string content);
    }
}