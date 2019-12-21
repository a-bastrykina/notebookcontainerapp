namespace Logic.UserInterface
{
    public interface SerializeCommandInput
    {
        string GetFileName();
        void ReportProblemsWithSerialization();
    }
}