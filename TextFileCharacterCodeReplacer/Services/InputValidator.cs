namespace TextFileCharacterCodeReplacer.Services
{
    using TextFileCharacterCodeReplacer.Services.Interfaces;

    public class InputValidator : IInputValidator
    {
        public bool IsFilePathValid(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }
    }
}
