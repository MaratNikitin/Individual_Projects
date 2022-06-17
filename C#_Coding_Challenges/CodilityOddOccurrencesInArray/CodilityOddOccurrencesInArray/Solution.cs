/*
 * It's a specific example of a Codility's C# coding challenge
 * The task is explained in a separate MS Word document that can be found in this repo
 * Author: Marat Nikitin
 * When: June 2022.
 */

using System;
using System.Linq;

namespace CodilityOddOccurrencesInArray
{
    class Solution
    {
        static void Main(string[] args)
        {
            int [] testArray = { 9, 3, 9, 3, 13, 6, 8, 9, 7, 9, 7, 8, 6};
            solution(testArray);
        }

        // This solution is short and sweet, built-in .Aggregate() function does the magic:
        public static int solution(int[] A)
        {
            int oddOccurence = A.Aggregate((x, y) => x ^ y);
            Console.WriteLine("Odd occurence is the number " + oddOccurence);
            return oddOccurence;
        }

            /*
            // This solutions works perfectly, but I am afraid that it's inefficient
                // for large arrays because of a nested loop:
            public static int solution(int[] A)
            {
                int temporaryCounter = 0;
                int oddOccurence = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < A.Length; j++)
                    {
                        if (A[j] == A[i]) // checking for a match
                        {
                            temporaryCounter++; 
                        }
                    }
                    if ((temporaryCounter % 2) == 1) // true if a number of occurences was odd
                    {
                        oddOccurence = A[i]; // a value to be returned is assigned
                        break; // once a number with an odd number of occurences is found - mission accomplished
                    }
                    temporaryCounter = 0; // resetting the temporary counter before moving to the next element
                }
                Console.WriteLine("Odd occurence is the number " + oddOccurence);
                return oddOccurence;
            }
            */
        }
}
