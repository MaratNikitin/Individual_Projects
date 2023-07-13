using System.Text;

static bool CheckIfStringIsAPalindrome(String input)
{
    if (String.IsNullOrEmpty(input))
    {
        return false;
    }

    StringBuilder reversed = new StringBuilder();
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed.Append(input[i]);
    }

    string reversedString = reversed.ToString();
    return reversedString.ToLower().Equals(input.ToLower()); // checking as case-insensitive
}

Console.WriteLine(CheckIfStringIsAPalindrome("Civic")); // should be True
Console.WriteLine(CheckIfStringIsAPalindrome("civic")); // should be True
Console.WriteLine(CheckIfStringIsAPalindrome("RaceCar")); // should be True
Console.WriteLine(CheckIfStringIsAPalindrome("Madam")); // should be True
Console.WriteLine(CheckIfStringIsAPalindrome("abba")); // should be True
Console.WriteLine(CheckIfStringIsAPalindrome(null)); // should be False
Console.WriteLine(CheckIfStringIsAPalindrome("")); // should be False
Console.WriteLine(CheckIfStringIsAPalindrome("")); // should be False
Console.WriteLine(CheckIfStringIsAPalindrome("swims")); // should be False
Console.WriteLine(CheckIfStringIsAPalindrome("mad")); // should be False
Console.WriteLine(CheckIfStringIsAPalindrome("Wi-Fi")); // should be False