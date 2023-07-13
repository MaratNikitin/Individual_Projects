using System.Text;

int[] inputNumbers = { 5, 3, 2, 5, 7, 0, 1 }; // 35 is the correct answer here
//int[] inputNumbers = { -2, -1, -3, 4, -8, 0 }; // 24 is the correct answer here
//int[] inputNumbers = { -2}; // it's an incorrect input
StringBuilder inputNumbersSB = new StringBuilder(); 

int FindMaximumMultiplicationProductInArray(int[] numbersArray)
{
    inputNumbersSB = new StringBuilder();
    if (inputNumbers.Length < 2)
    {
        Console.WriteLine("The input array has less than 2 elements, so this method does not make sense, returning sentinel value.");
        return Int32.MinValue;
    }

    int maximumProduct = Int32.MinValue;

    for (int i = 0; i < numbersArray.Length; i++)
    {
        for (int j = 0; j < numbersArray.Length; j++)
        {
            if (i == j) // if it's the same element, wejust skip it
            {
                continue;
            }

            if (numbersArray[i] * numbersArray[j] > maximumProduct) {
                maximumProduct = numbersArray[i] * numbersArray[j];
            }
        }
        inputNumbersSB.Append(inputNumbers[i] + "; ");
    }
    return maximumProduct;
}

Console.WriteLine($"The maximum product of multiplication of two different array elements is {FindMaximumMultiplicationProductInArray(inputNumbers)}");
if (inputNumbers.Length > 1)
{
    Console.WriteLine($"The input array: {inputNumbersSB}");
}


