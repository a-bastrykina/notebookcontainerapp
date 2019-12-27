using Notebook;


namespace Logic.UserInterface
{
    [Attributes.CommonElement]
    public interface AddCommandInput
    {
        INote GetNote();
    }
}
