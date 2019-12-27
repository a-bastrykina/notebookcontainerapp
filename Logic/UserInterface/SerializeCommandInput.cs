namespace Logic.UserInterface
{
    [Attributes.CommonElement]
    public interface SerializeCommandInput
    {
        string GetFileName();
        void ReportProblemsWithSerialization();
    }
}