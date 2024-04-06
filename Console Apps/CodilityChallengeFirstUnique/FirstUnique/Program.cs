int GetFirstUniqueNumberInArray(int[] A){
    List<int> uniqueIntegersList = new List<int>();
    List<int> duplicateIntegersList = new List<int>();
    int returnValue = -1;

    foreach (int number in A)
    {
        if (uniqueIntegersList.Contains(number))
        {
            uniqueIntegersList.Remove(number);
            duplicateIntegersList.Add(number);
        }
        else
        {
            if (!duplicateIntegersList.Contains(number)) 
            { 
                uniqueIntegersList.Add(number);
            }
        }
    }

    if (uniqueIntegersList.Count > 0)
    {
        returnValue = uniqueIntegersList[0];
    }

    return returnValue;

}

//int[] testArray = new int[] {4,10,5,4,2,10};
//int[] testArray = new int[] {1,4,3,3,1,2};
int[] testArray = new int[] { 6,4,4,6 };

Console.WriteLine($"The first unique number in the array is {GetFirstUniqueNumberInArray(testArray)}.");
