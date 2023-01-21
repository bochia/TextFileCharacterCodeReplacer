using TextFileCharacterCodeReplacer.Models;
using TextFileCharacterCodeReplacer.Services;
using TextFileCharacterCodeReplacer.Services.Interfaces;

//Below is website for finding html codes
//https://www.toptal.com/designers/htmlarrows/symbols/

IInputValidator inputValidator = new InputValidator();
IPromptService promptService = new PromptService(inputValidator);
ICharacterCodesRetriever characterCodesRetriever = new CharacterCodesRetriever();

try
{
    string textFilePath = string.Empty;
    textFilePath = promptService.PromptUserForInputTextFilePath();

    string csvFilePath = string.Empty;
    csvFilePath = promptService.PromptUserForCharacterCodeCsvFilePath();

    Console.WriteLine("Opening up csv file to retrieve character and character code pairs.");
    IEnumerable<CharacterCodePair> characterCodePairs = characterCodesRetriever.GetCharacterCodePairsFromFile(csvFilePath);
    if (characterCodePairs == null || characterCodePairs.Count() == 0)
    {
        throw new Exception("No character code records found in csv file.");
    }

    Console.WriteLine("Reading contents of text file...");
    string textFileContents = File.ReadAllText(textFilePath);
    string updatedTextFileContents = textFileContents;

    Console.WriteLine("Beginning replacement of characters with character codes...");
    foreach (CharacterCodePair characterCodePair in characterCodePairs)
    {
        Console.WriteLine($"Replacing all occurences of {characterCodePair.Character} with {characterCodePair.CharacterCode}");
        //TODO: Can this be more efficient with strings?
        updatedTextFileContents = updatedTextFileContents.Replace(characterCodePair.Character,
                                                                  characterCodePair.CharacterCode);
    }
    Console.WriteLine("Finished replacing all desired characters.");

    Console.WriteLine("Attempting to write text file updates to output file.");
    string textFileExtension = Path.GetExtension(textFilePath);
    string outputFilePrefix = "_Converted";
    string outputFilePath = $"{textFilePath.Replace(textFileExtension, string.Empty)}{outputFilePrefix}{textFileExtension}";
    File.WriteAllText(outputFilePath, updatedTextFileContents);
    Console.WriteLine($"Successfully wrote updates to output file. Location: {outputFilePath}");

    // keep console open until user decides to close.
    Console.Write("Press enter to close this console...");
    Console.Read();
}
catch (Exception ex)
{
    promptService.WriteErrorToConsole(ex.Message);
    Console.WriteLine("Program execution will now end.");
}

// if something wrong with csv data give line number or some other info to help the user find it.
//need to clean data that comes in - remove new line characters, tabs, etc...

//TODO: Add unit test project.
//TODO: Add a test integration project that takes an actual file and changes it.
//TODO: Create a build process that will package everything up in a zip file for the user to open and use.
//TODO: Add depedency injection.