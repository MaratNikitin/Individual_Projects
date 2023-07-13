using System.Text;

static string ReverseAWord(string input)
{
    if (String.IsNullOrEmpty(input))
    {
        return "";
    }

    StringBuilder reversed = new StringBuilder();
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed.Append(input[i]);
    }

    return reversed.ToString();
}

static string ReverseEachWordInASentence(string input)
{
    if (String.IsNullOrEmpty(input))
    {
        return "";
    }

    string [] words = input.Split(" ");
    StringBuilder sentenceWithReversedWords = new();
    foreach (string word in words)
    {
        sentenceWithReversedWords.Append(ReverseAWord(word) + " ");
    }
    sentenceWithReversedWords.Length--;
    return sentenceWithReversedWords.ToString();
}

string testSentence = "Today is July 13th 2023";
Console.WriteLine($"Original sentence: {testSentence}.");
Console.WriteLine($"Sentence with each word reversed: {ReverseEachWordInASentence(testSentence)}.");
