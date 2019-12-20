using Attributes;

namespace Notebook.NoteFactory
{
    [ContainerElement]
    public interface INoteFactory
    {
        string TypeName { get; }
        INote createFromCommandLine(string content);
    }
}