/*
 * It's a specific example of a Codility's C# coding challenge
 * The task is explained in a separate MS Word document that can be found in this repo
 * Author: Marat Nikitin
 * When: June 2022.
 */

using System;

namespace CodilityChallengeJumpingFrog
{
    class Solution
    {
        static void Main(string[] args)
        {
            int x = 10; // initial coordinate
            int y = 85; // target coordinate
            int d = 30; // length of a single jump
            int minNumberOfJumps1 = solution(x, y, d);
            Console.WriteLine("x = " + x + "; y = " + y + "; d = " + d + "; minimal number of jumps required: " + minNumberOfJumps1);
        }

        public static int solution (int x, int y, int d)
        {
            // x - start position, y - end position, d - one jump distance

            // typecasting every integer to decimal is required for correct calculations:
            decimal numberOfJumpsBeforeRounding = ((decimal)y - (decimal)x) / (decimal)d;
            int minimalNumberOfJumps = (int) Math.Ceiling(numberOfJumpsBeforeRounding); // rounding to the upper integer value 
            return minimalNumberOfJumps;
        }
    }
}
