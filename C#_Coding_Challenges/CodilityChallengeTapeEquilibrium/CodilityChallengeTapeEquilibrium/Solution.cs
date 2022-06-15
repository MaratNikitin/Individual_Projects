/*
 * It's a specific example of a Codility's C# coding challenge
 * The task is explained in a separate MS Word document that can be found in this repo
 * Author: Marat Nikitin
 * When: June 2022.
 */

using System;
using System.Linq;

namespace CodilityChallengeTapeEquilibrium
{
    class Solution
    {
        static void Main(string[] args)
        {
            int[] testArray = { 3,1,2,4,3 };
            solution(testArray);
        }

        public static int solution(int[] A)
        {
            int arraySum = A.Sum(); // sum of all the array's elements
            int minimumDifference = A.Max(); // to make sure that it's a large enough number to begin with
            int currentDifference = A.Max(); // to make sure that it's a large enough number to begin with
            int currentSum = 0; // represents sum of first array elements until the current point

            // a single loop with with a limited number (= A.Length) of iterations should make this algorithm efficient:
            for (int i = 0; i < A.Length; i++)
            {
                currentSum += A[i]; // cumulative sum of array's elements
                currentDifference = Math.Abs(currentSum - (arraySum - currentSum));
                if (currentDifference < minimumDifference)
                {
                    minimumDifference = currentDifference;
                }
            }
            Console.WriteLine("The input array:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + "  ");
            }
            Console.WriteLine("The minimal difference is " + minimumDifference);
            return minimumDifference;
        }
    }
}
