//Console.WriteLine("Hello, World!");

//string response;
//Console.WriteLine("What's you name?");
//response = Console.ReadLine() ?? "";
//Console.WriteLine($"Enjoy the course, {response}!");

//OperatingSystem thisOS = Environment.OSVersion;
//Console.WriteLine($"Platform: {thisOS.Platform}; Version: {thisOS.VersionString}");

//// value type examples:
//int a = 1;
//char c = 'g';
//float f = 123.45f;
//decimal d = 400.85m;
//int b = default(int);
//bool tf = default(bool);

//Console.WriteLine($"a = {a}, b = {b}, tf = {tf}, c = {c}, f = {f}, d = {d}");

//// implicit type conversion is demonstrated below:
//Console.WriteLine($"Implicit conversion (a + c) result: {a + c}");
//Console.WriteLine($"Conversion (a+c) result as explicit char: {(char)(a + c)}");
//Console.WriteLine($"Implicit conversion (a + f) result: {a + f}");
//Console.WriteLine($"Implicit conversion (c + f) result: {c + f}");

//float f1 = 123.4f;
//int i1 = 2000;

//// Old school way:
//Console.WriteLine("{0, -15} {1, 10}", "Float Val", "Int Val");
//Console.WriteLine("{0, -15} {1, 10}", f1, i1);

//// String interpolation
//Console.WriteLine($"{"Float Val", -15} {"Int Val", 10}");
//Console.WriteLine($"{f1, -15} {i1, 10}");

//string str1 = "The quick brown fox jumps over the lazy dog";
//string str2 = "This is a string";
//string str3 = "THIS is a STRING";
//string[] str4 = { "one", "two", "three", "four" };

//// Length of a string 
//Console.WriteLine(str1.Length);

//// Accessing individual chatacters:
//Console.WriteLine(str1[14]);

//// Iterate through the string
//foreach (char ch in str1)
//{
//    Console.WriteLine(ch);
//    if (ch == 'b') {
//        Console.WriteLine();
//        break;
//    }
//}

//// String concatenation
//string outString;
//outString = String.Concat(str4);
//Console.WriteLine(outString);

//// Joining strings
//outString = String.Join(" ", str4);
//Console.WriteLine(outString);

//// Comparing strings:
//bool isEqual = str2.Equals(str3);
//Console.WriteLine(isEqual);

//isEqual = str2.ToUpper().Equals(str3.ToUpper());
//Console.WriteLine(isEqual);

//int result = String.Compare(str2, "This is a string");
//Console.WriteLine(result);

//string outString = str1.Replace("fox", "cat");
//Console.WriteLine(outString);

/******************************************************************************************************************************************************************/

// Coding challenge 1 from the 'C# and .NET Essential Training' LinkedIn Learning course 
// A user is requested to enter a date in any valid format and then the app responds by showing how far is that entered date from the current date

//using System.Collections.Concurrent;

//while(true)
//{
//    string inputString;
//    Console.WriteLine("Which date? (or 'exit')");
//    inputString = Console.ReadLine() ?? "";
//    DateTime inputDate;
//    DateTime todaysDate = DateTime.Today;

//    if(inputString == "exit")
//    {
//        Environment.Exit(0);
//    }

//    if (DateTime.TryParse(inputString, out inputDate))
//    {
//        int dateDifferenceInDays = (todaysDate - inputDate).Days;
//        switch (dateDifferenceInDays)
//        {
//            case 0:
//                Console.WriteLine("That day is today!");
//                break;
//            default:
//                if (dateDifferenceInDays > 0)
//                {
//                    Console.WriteLine($"That day went by {dateDifferenceInDays} days ago!");
//                }
//                else
//                {
//                    Console.WriteLine($"That day will be in {-dateDifferenceInDays} days!");
//                };
//                break;
//        }
//    }
//    else
//    {
//        Console.WriteLine("That doesn't seem to be a valid date");
//    }
//    Console.WriteLine();
//}

/******************************************************************************************************************************************************************/

// Coding challenge 2 from the 'C# and .NET Essential Training' LinkedIn Learning course 
// A folder contains various MS Office file. A txt file report is created showing statistics regarding those files.
using System.Globalization;

string currentDirectoryPath = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectoryPath);
string folderAnalyzedPath = @"C:\\Users\\maratn\\Desktop\\MN\\Individual_Projects\\Console Apps\\ConsoleAppLinkedInLearningDec2022\\ConsoleAppLinkedInLearningDec2022\\FilesCollection";
DirectoryInfo directoryInfo = new DirectoryInfo(folderAnalyzedPath);
List<string> theFiles = new List<string>(Directory.EnumerateFiles(folderAnalyzedPath));

// Counters for file numbers:
int excelFilesNumber = 0;
int wordFilesNumber = 0;
int powerPointFilesNumber = 0;

// File size counters:
long excelFilesTotalSize = 0;
long wordFilesTotalSize = 0;
long powerPointFilesTotalSize = 0;

int fileSequenceNumber = 0;

// Collecting statistics
foreach (string file in theFiles)
{
    
    fileSequenceNumber++;
    string lastFourChar = file.Substring(file.Length - 4);
    FileInfo fi = new FileInfo(file);

    if (lastFourChar == "xlsx")
    {
        excelFilesNumber++;
        excelFilesTotalSize += fi.Length;
        //Console.WriteLine($"File number: {fileSequenceNumber}; file name: {file.Substring(file.Length - 6)}; file size: {fi.Length}" );
    }
    else if (lastFourChar == "docx")
    {
        wordFilesNumber++;
        wordFilesTotalSize += fi.Length;
        //Console.WriteLine($"File number: {fileSequenceNumber}; file name: {file.Substring(file.Length - 6)}; file size: {fi.Length}");
    }
    else if (lastFourChar == "pptx")
    {
        powerPointFilesNumber++;
        powerPointFilesTotalSize += fi.Length;
        //Console.WriteLine($"File number: {fileSequenceNumber}; file name: {file.Substring(file.Length - 6)}; file size: {fi.Length}");
    }
    else
    {
        //Console.WriteLine($"File number: {fileSequenceNumber}; file name: {file.Substring(file.Length - 6)}; file size: {fi.Length}");
        continue;
    }
}

int totalNumberOfMSOfficeFiles = excelFilesNumber + wordFilesNumber + powerPointFilesNumber;
long totalMSOfficeFilesSize = excelFilesTotalSize + wordFilesTotalSize + powerPointFilesTotalSize;

const string resultsFileName = "results.txt";

if (File.Exists(resultsFileName))
{
    File.Delete(resultsFileName);
}

// Writing the results into the new 'results.txt' file located in the \bin\debug\net6.0 folder

File.WriteAllText(resultsFileName, "~~~~ Results ~~~~");
using (StreamWriter sw = File.AppendText(resultsFileName))
{
    sw.WriteLine();
    sw.WriteLine($"Total Files: {totalNumberOfMSOfficeFiles}");
    sw.WriteLine($"Excel Count: {excelFilesNumber}");
    sw.WriteLine($"Word Count: {wordFilesNumber}");
    sw.WriteLine($"PowerPoint Count: {powerPointFilesNumber}");
    sw.WriteLine($"----");
    sw.WriteLine($"Total Size: {totalMSOfficeFilesSize.ToString("N0")}");
    sw.WriteLine($"Excel Size: {excelFilesTotalSize.ToString("N0")}");
    sw.WriteLine($"Word Size: {wordFilesTotalSize.ToString("N0")}");
    sw.WriteLine($"PowerPoint Size: {powerPointFilesTotalSize.ToString("N0")}");
}