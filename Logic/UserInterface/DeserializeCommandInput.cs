namespace Logic.UserInterface
{
    [Attributes.CommonElement]
    public interface DeserializeCommandInput
    {
        string GetFileName();
        void ReportProblemsWithDeserialization();
    }
}