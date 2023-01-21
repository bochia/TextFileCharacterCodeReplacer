namespace TextFileCharacterCodeReplacer.Services
{
    using CsvHelper;
    using System.Collections.Generic;
    using System.Globalization;
    using TextFileCharacterCodeReplacer.Models;
    using TextFileCharacterCodeReplacer.Services.Interfaces;

    public class CharacterCodesRetriever : ICharacterCodesRetriever
    {
        public IEnumerable<CharacterCodePair> GetCharacterCodePairsFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(filePath);
            }

            IEnumerable<CharacterCodePair> records;

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<CharacterCodePair>().ToList();
                }
            }

            return records;
        }
    }
}
