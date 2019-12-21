namespace Logic.UserInterface
{
    public interface DeserializeCommandInput
    {
        string GetFileName();
        void ReportProblemsWithDeserialization();
    }
}