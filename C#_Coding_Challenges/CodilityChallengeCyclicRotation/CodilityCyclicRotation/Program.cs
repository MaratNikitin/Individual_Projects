using System;

namespace CodilityCyclicRotation
{
    class Solution
    {
        static void Main(string[] args)
        {
            int[] initialArray = { 1, 2, 3, 4};
            int K = 4;
            solution(initialArray, K); // testing the function
        }

        public static int[] solution(int[] A, int K)
        {
            int[] rotatedArray = new int[A.Length]; // rotated array has the same number of elements
            int newIndex = 0; // new index of an element after rotation is represented here
            // if an array of 4 elements needs to be rotated 7 times, it's equivalent to rotating it 3 times only:
            int numberOfRequiredRotations = K % (A.Length); 
            
            for (int i=0; i<A.Length; i++)
            {
                // newIndex is the new index of the element with the former index i:
                newIndex = (i + numberOfRequiredRotations) % (A.Length);
                // that's where the "rotation" happens, a new array elements are the rotated array:
                rotatedArray[newIndex] = A[i]; 
            }
            
            // user-friendly display of the initial array:
            Console.Write("The initial array: [");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + ", ");
            }
            Console.WriteLine("]");

            
            Console.WriteLine("K = " + K + "; Number of real rotations: " + numberOfRequiredRotations);

            // user-friendly display of the rotated array to be returned:
            Console.Write("The rotated array: [");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(rotatedArray[i] + ", ");
            }
            Console.WriteLine("]");

            return rotatedArray; // returning the rotated array; mission accomplished.
        }
    }
}
