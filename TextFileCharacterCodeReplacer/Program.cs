using TextFileCharacterCodeReplacer.Models;
using TextFileCharacterCodeReplacer.Services;
using TextFileCharacterCodeReplacer.Services.Interfaces;

//Below is website for finding html codes
//https://www.toptal.com/designers/htmlarrows/symbols/

string textFilePath = string.Empty;
string csvFilePath = string.Empty;

//if (args == null || args.Count() == 0)
//{
//    //promp the user for both args.
//}
//else if (args.Count() == 1)
//{

//    //print the value for the first arg then request the 2nd arg
//}
//else
//{
//    // display arg values and move on.
//}



////add defensive coding.
////check that the file exists.
////add while loop to keep prompting until you get inputs that are valid

//bool areInputsValid = false;
//bool isTextFilePathValid = false;
//bool isCsvFilePathValid = false;

//while (!areInputsValid)
//{
//    if (!isTextFilePathValid)
//    {
//        //prompt for input
//        continue;
//    }

//    if (!isCsvFilePathValid)
//    {
//        //prompt for input
//        continue;
//    }
//}


csvFilePath = @"C:\Users\John\source\repos\TextFileCharacterCodeReplacer\TextFileCharacterCodeReplacer\TestCsv\CharactersAndCodes.csv";
textFilePath = @"C:\Users\John\source\repos\TextFileCharacterCodeReplacer\TextFileCharacterCodeReplacer\TestCsv\ExampleHtmlFile.html";
string textFileExtension = Path.GetExtension(textFilePath);
string outputFileName = "DevelopmentOutputFileName"; //TODO: Should this also be an input?
string outputFilePath = $@"C:\Users\John\source\repos\TextFileCharacterCodeReplacer\TextFileCharacterCodeReplacer\TestCsv\{outputFileName}{textFileExtension}";

try
{
    //TODO: Add depedency injection.
    ICharacterCodesRetriever characterCodesRetriever = new CharacterCodesRetriever();

    IEnumerable<CharacterCodePair> characterCodePairs = characterCodesRetriever.GetCharacterCodePairsFromFile(csvFilePath);
    if (characterCodePairs == null)
    {
        //TODO: prompt user that error happened.
    }

    string textFileContents = File.ReadAllText(textFilePath);
    string updatedTextFileContents = textFileContents;

    foreach (CharacterCodePair characterCodePair in characterCodePairs)
    {
        //TODO: Can this be more efficient with strings?
        updatedTextFileContents = updatedTextFileContents.Replace(characterCodePair.Character,
                                                                  characterCodePair.CharacterCode);
    }

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
