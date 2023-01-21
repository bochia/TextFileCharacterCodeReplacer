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
    string textFileExtension = Path.GetExtension(textFilePath);

    string csvFilePath = string.Empty;
    csvFilePath = promptService.PromptUserForCharacterCodeCsvFilePath();


    IEnumerable<CharacterCodePair> characterCodePairs = characterCodesRetriever.GetCharacterCodePairsFromFile(csvFilePath);
    if (characterCodePairs == null || characterCodePairs.Count() == 0)
    {
        promptService.WriteErrorToConsole("No characte");
    }

    string textFileContents = File.ReadAllText(textFilePath);
    string updatedTextFileContents = textFileContents;

    foreach (CharacterCodePair characterCodePair in characterCodePairs)
    {
        //TODO: Can this be more efficient with strings?
        updatedTextFileContents = updatedTextFileContents.Replace(characterCodePair.Character,
                                                                  characterCodePair.CharacterCode);
    }

    string outputFileName = "DevelopmentOutputFileName"; //TODO: Should this also be an input?
    string outputFilePath = $@"C:\Users\John\source\repos\TextFileCharacterCodeReplacer\TextFileCharacterCodeReplacer\TestCsv\{outputFileName}{textFileExtension}";
    File.WriteAllText(outputFilePath, updatedTextFileContents);
}
catch (Exception ex)
{
    //TODO: Add some type of prompt to the user.
    throw;
}

// if something wrong with csv data give line number or some other info to help the user find it.
//need to clean data that comes in - remove new line characters, tabs, etc...

//TODO: Add unit test project.
//TODO: Add a test integration project that takes an actual file and changes it.
//TODO: Create a build process that will package everything up in a zip file for the user to open and use.
//TODO: add logs to user can see what is happening.
//TODO: Add depedency injection.
