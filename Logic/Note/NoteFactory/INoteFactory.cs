namespace Notebook.NoteFactory
{
    [Attributes.CommonElement]
    public interface INoteFactory
    {
        string TypeName { get; }
        INote createFromCommandLine(string content);

        INote createFromKeyValue(string key, string value);
    }
}