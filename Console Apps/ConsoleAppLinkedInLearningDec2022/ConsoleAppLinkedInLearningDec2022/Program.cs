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


// Coding challenge from the 'C# and .NET Essential Training' LinkedIn Learning course 
using System.Collections.Concurrent;

while(true)
{
    string inputString;
    Console.WriteLine("Which date? (or 'exit')");
    inputString = Console.ReadLine() ?? "";
    DateTime inputDate;
    DateTime todaysDate = DateTime.Today;

    if(inputString == "exit")
    {
        Environment.Exit(0);
    }

    if (DateTime.TryParse(inputString, out inputDate))
    {
        int dateDifferenceInDays = (todaysDate - inputDate).Days;
        switch (dateDifferenceInDays)
        {
            case 0:
                Console.WriteLine("That day is today!");
                break;
            default:
                if (dateDifferenceInDays > 0)
                {
                    Console.WriteLine($"That day went by {dateDifferenceInDays} days ago!");
                }
                else
                {
                    Console.WriteLine($"That day will be in {-dateDifferenceInDays} days!");
                };
                break;
        }
    }
    else
    {
        Console.WriteLine("That doesn't seem to be a valid date");
    }
    Console.WriteLine();
}

