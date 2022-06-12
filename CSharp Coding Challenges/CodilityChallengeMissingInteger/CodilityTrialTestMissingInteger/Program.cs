/*
 * It's a specific example of a specific Codility coding challenge, the solution2 method is the right solution
 * The task is explained in a separate MS Word document that can be found in this repo
 * Author: Marat Nikitin
 * When: June 2022.
 */

using System;
using System.Linq;

namespace CodilityTrialTestMissingInteger
{
    public class Solution
    {
        static void Main(string[] args)
        {
            //int[] inputArray1 = {3, 1, 5, 2}; // the right answer is 4
            //int[] inputArray1 = { -3, -1, -5, -2 }; // the right answer is 1
            int[] inputArray1 = { 3, 1, 5, 2, 4 }; // the right answer is 6

            Console.Write("The initial array: [");
            for (int i=0; i<inputArray1.Length; i++)
            {
                Console.Write(inputArray1[i] + ", ");
            }
            Console.WriteLine("]");

            int myMissingInt1 = solution1(inputArray1);
            Console.WriteLine("The missing integer of the array is " + myMissingInt1);

            
            int myMissingInt2 = solution2(inputArray1);
            Console.WriteLine("The missing integer of the array is " + myMissingInt2);
            
        }
        
        // this function works but fails the performance tests because of a loop inside a loop:
        public static int solution1(int[] A)
        {
            int missingInteger = 1;
            for (int i=0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] == missingInteger)
                    {
                        missingInteger++;
                    }
                }
                if (A[i] == missingInteger)
                {
                    missingInteger++;
                }
            }
            return missingInteger;
        }

        // this function has a single loop, meets all requirements and gives 100% result !!!:
        public static int solution2(int[] A)
        {
            int missingInteger = 1;
            Array.Sort(A); // sorting the array elements in the ascending order
            if(A[0]>1)
            {
                return 1; // if the first element after the sorting is more than 1, that's it - 1 is the right answer
            }
            for (int i=0; i<A.Length; i++) // looping through all array elements only once
            {
                if (A[i] == missingInteger) // if the next element is present, then the missing one should be a higher value
                {
                    missingInteger++;
                }
            }
            return missingInteger;
        }
    }
}
