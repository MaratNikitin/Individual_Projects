using System.Text;

string GetABCombinations(int A, int B)
{
    StringBuilder stringBuilder = new StringBuilder();
    int remainingAs = A;
    int remainingBs = B;
    int consecutiveAsCounter = 0;
    int consecutiveBsCounter = 0;

    for (int i = 0; i < A+B; i++)
    {
        if(remainingAs > remainingBs && consecutiveAsCounter < 2)
        {
            stringBuilder.Append("a");
            remainingAs--;
            consecutiveAsCounter++;
            consecutiveBsCounter = 0;
            continue;
        }

        if (remainingBs > remainingAs && consecutiveBsCounter < 2)
        {
            stringBuilder.Append("b");
            remainingBs--;
            consecutiveBsCounter++;
            consecutiveAsCounter = 0;
            continue;
        }

        if (consecutiveBsCounter == 2)
        {
            stringBuilder.Append("a");
            remainingAs--;
            consecutiveAsCounter++;
            consecutiveBsCounter = 0;
            continue;
        }

        if (consecutiveAsCounter == 2)
        {
            stringBuilder.Append("b");
            remainingBs--;
            consecutiveBsCounter++;
            consecutiveAsCounter = 0;
            continue;
        }

        if (consecutiveAsCounter >= consecutiveBsCounter)
        {
            stringBuilder.Append("a");
            remainingAs--;
            consecutiveAsCounter++;
            consecutiveBsCounter = 0;
            continue;
        }
        else
        {
            stringBuilder.Append("b");
            remainingBs--;
            consecutiveBsCounter++;
            consecutiveAsCounter = 0;
            continue;
        }
    }

    return stringBuilder.ToString();
}

int numberOfAs = 5;
int numberOfBs = 3;

string result = GetABCombinations(numberOfAs, numberOfBs);
Console.WriteLine($"The resulting string for A = {numberOfAs} and B = {numberOfBs}: {result}");
