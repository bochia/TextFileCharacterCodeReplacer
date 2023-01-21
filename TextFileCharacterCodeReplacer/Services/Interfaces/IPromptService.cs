namespace TextFileCharacterCodeReplacer.Services.Interfaces
{
    public interface IPromptService
    {
        string PromptUserForInputTextFilePath();
        string PromptUserForCharacterCodeCsvFilePath();
        string WriteError(string errorMessage);
    }
}
