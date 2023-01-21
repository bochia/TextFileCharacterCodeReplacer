string textFilePath = string.Empty;
string csvFilePath = string.Empty;

if (args == null || args.Count() == 0)
{
    //promp the user for both args.
}
else if (args.Count() == 1)
{

    //print the value for the first arg then request the 2nd arg
}
else
{
    // display arg values and move on.
}

//add defensive coding.
//check that the file exists.
//add while loop to keep prompting until you get inputs that are valid

bool areInputsValid = false;
bool isTextFilePathValid = false;
bool isCsvFilePathValid = false;

while (!areInputsValid)
{
    if (!isTextFilePathValid)
    {
        //prompt for input
        continue;
    }

    if (!isCsvFilePathValid)
    {
        //prompt for input
        continue;
    }
}



// if something wrong with csv data give line number or some other info to help the user find it.
//need to clean data that comes in - remove new line characters, tabs, etc...
