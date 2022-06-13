/*
 * It's a specific example of a Codility's coding challenge
 * The task is explained in a separate MS Word document that can be found in this repo
 * Author: Marat Nikitin
 * When: June 2022.
 */

using System;

namespace CodilityChallengeBinaryGap
{
    class Solution
    {
        static void Main(string[] args)
        {
            solution(1041); // the right answer is 5
            solution(32); // the right answer is 0
            solution(500);
        }

        public static int solution(int N)
        {
            string binary = Convert.ToString(N, 2);
            Console.WriteLine("The number N = " + N + ", its binary value is " + binary);
            int maxBinaryGap = 0; // the value to be returned as an answer
            int gapCounter = 0; // temporary gap counter variable
            // temporary max gap variable (can be discarded if there is no "1" character in the end):
            int currentBinaryGap = 0; 
            // there is only a single loop here, so performance should be fine
            foreach (char c in binary) // looping through characters of a binary number string
            {
                if (c == '0')
                {
                    gapCounter++;
                    if (gapCounter > currentBinaryGap)
                    {
                        currentBinaryGap = gapCounter;
                    }
                }
                else // it means that "1" character was encountered
                {
                    if (currentBinaryGap > maxBinaryGap) // true if we met a new binary gap record
                    {
                        maxBinaryGap = currentBinaryGap;
                    }
                    gapCounter = 0; // "1" was encountered, so this variable is reset back to 0
                    currentBinaryGap = 0; // "1" was encountered, so this variable is reset back to 0
                }               
            }
            Console.WriteLine("Max binary gap for the number" + N + " is " + maxBinaryGap);
            Console.WriteLine(""); // for better display
            return maxBinaryGap;
        }
    }
}
