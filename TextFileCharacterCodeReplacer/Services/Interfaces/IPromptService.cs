namespace TextFileCharacterCodeReplacer.Services.Interfaces
{
    public interface IPromptService
    {
        /// <summary>
        /// Recursively prompt user to enter file path to csv valid input is given.
        /// </summary>
        /// <returns></returns>
        /// 
        string PromptUserForInputTextFilePath();
        /// <summary>
        /// Recursively prompt user to enter file path to csv valid input is given.
        /// </summary>
        /// <returns></returns>
        string PromptUserForCharacterCodeCsvFilePath();

        /// <summary>
        /// Writes error to console with prefix to indicate its an error.
        /// </summary>
        /// <param name="errorMessage"></param>
        void WriteErrorToConsole(string errorMessage);
    }
}
