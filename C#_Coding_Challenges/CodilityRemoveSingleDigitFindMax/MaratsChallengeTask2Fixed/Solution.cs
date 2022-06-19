/* 
Codility challenge #2, task 2 fixed
Author: Marat Nikitin
Date: June 13, 2022
*/

using System;
using System.Linq;

namespace MaratsChallengeTask2Fixed
{
    class Solution
    {
        static void Main(string[] args)
        {
            int number = 510005;
            solution(number);

            int number2 = 5000;
            solution(number2);

            int number3 = 10565;
            solution(number3);

            int number4 = 590005;
            solution(number4);
        }

        public static int solution(int N)
        {

            string stringNumber = N.ToString();
            int counterOfFives = 0;

            // finding the number of '5' characters in the string first:
            foreach (char c in stringNumber)
            {
                if (c == '5')
                {
                    counterOfFives++;
                }
            }

            // creating an array for holding array indexes of fives in the stringNumber:
            int[] indexesOfFives = new int[counterOfFives];

            int numberOfElementsInIndexesOfFives = 0; // for entered elements
            for (int i = 0; i < stringNumber.Length; i++)
            {
                if (stringNumber[i] == '5')
                {
                    indexesOfFives[numberOfElementsInIndexesOfFives] = i;
                    numberOfElementsInIndexesOfFives++;
                }
            }

            // this array will hold possible integers for comparison:
            int[] arrayOfPossibleIntegers = new int[counterOfFives]; // !!! fixed here, removed '-1'
            for (int i = 0; i < (counterOfFives); i++) // !!! fixed here, removed '-1'
            {
                string temporaryNumberString = stringNumber;
                // !!! fixed in the next line, introduced a separate 'stringWithoutOne5Digit' variable
                string stringWithoutOne5Digit = temporaryNumberString.Remove(indexesOfFives[i], 1);
                arrayOfPossibleIntegers[i] = Int32.Parse(stringWithoutOne5Digit);
            }

            int resultToReturn = arrayOfPossibleIntegers.Max();

            Console.WriteLine("The initial analyzed number is " + stringNumber);
            Console.WriteLine("The largest number is with a singe '5' deleted is " + resultToReturn);
            Console.WriteLine();
            return resultToReturn;

        }
    }
}
