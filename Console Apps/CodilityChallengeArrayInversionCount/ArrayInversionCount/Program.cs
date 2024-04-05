const int N = 6;
int[] inputArray = new int[N] { -1, 6, 3, 4, 7, 4 };

//const int N = 3;
//int[] inputArray = new int[N] { 3,4,1 };

int CalculateNumberOfIntegers(int[] A)
{
    int inversionsCount = 0;

    for (int i = 0; i < A.Length; i++) 
    {
        for (int j = i+1; j < A.Length; j++) 
        {
            if (A[i] > A[j])
            {
                inversionsCount++;
            }
        }
    }

    return inversionsCount;
}

Console.WriteLine($"The number of inversions is {CalculateNumberOfIntegers(inputArray)}.");
