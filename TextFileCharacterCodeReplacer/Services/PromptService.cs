namespace TextFileCharacterCodeReplacer.Services
{
    using TextFileCharacterCodeReplacer.Services.Interfaces;

    public class PromptService : IPromptService
    {
        private readonly IInputValidator inputValidator;
        private const string ErrorPrefix = "ERROR: ";

        public PromptService(IInputValidator inputValidator)
        {
            this.inputValidator = inputValidator;
        }

        /// <inheritdoc />
        public string PromptUserForCharacterCodeCsvFilePath()
        {
            return PromptForFilePath("Enter path to csv file containing character codes: ");
        }

        /// <inheritdoc />
        public string PromptUserForInputTextFilePath()
        {
            return PromptForFilePath("Enter path to desired text file to be edited: ");
        }

        /// <inheritdoc />
        public void WriteErrorToConsole(string errorMessage)
        {
            Console.WriteLine($"{ErrorPrefix}{errorMessage}");
        }

        private string PromptForFilePath(string promptText)
        {
            Console.WriteLine(promptText);
            string? csvFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(csvFilePath))
            {
                WriteErrorToConsole("Input cannot be blank");
                PromptForFilePath(promptText);
            }

            if (!inputValidator.IsFilePathValid(csvFilePath))
            {
                WriteErrorToConsole("Invalid file path entered - file doesn't exist.\n");
                return PromptForFilePath(promptText);
            }

            return csvFilePath.ToString();
        }

    }
}
