namespace TextFileCharacterCodeReplacer.Services.Interfaces
{
    using TextFileCharacterCodeReplacer.Models;

    public interface ICharacterCodesRetriever
    {
        IEnumerable<CharacterCodePair> GetCharacterCodePairsFromFile(string filePath);
    }
}
