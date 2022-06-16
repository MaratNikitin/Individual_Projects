/*
Coding test;
Author: Marat Nikitin;
Date: June 12, 2022.
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace CodilityDocumentStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    // Do not change the name of this class
    public class DocumentProcessor //: IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        public Stats Analyze(string document)
        {
            // Console.WriteLine("Sample debug output");
            throw new NotImplementedException();

            Stats myStats = new Stats(); // creating an empty instance of the class to be returned later

            // counting number of all words in the document:
            string[] separateWords = document.Split(' '); // by definition each word is separated by a single space here
            myStats.NumberOfAllWords = separateWords.Length; // first class variable to be returned

            // finding the number of words that consist only of digits, e.g. 13455, 98374:
            int counterForDigitsOnlyWords = 0;
            for (int i = 0; i < separateWords.Length; i++) // iterating through separate words
            {
                bool isDigitsOnly = true; // assuming true until proven otherwise

                foreach (char c in separateWords[i]) // iterating through characters of each word
                {

                    if (c < '0' || c > '9') // true if a character is non-digit
                    {
                        isDigitsOnly = false;
                    }
                }

                if (isDigitsOnly = true) // it's true only if each character of the word checked was a digit
                {
                    counterForDigitsOnlyWords++;
                }
            } // each word was checked for digits only by this point 

            // saving a variable to be returned in the class object:
            myStats.NumberOfWordsThatContainOnlyDigits = counterForDigitsOnlyWords;


            // checking the number of words starting with a lower case charachter:
            int numberOfWordsStartingWithLowercaseLetter = 0;

            for (int i = 0; i < separateWords.Length; i++) // iterating through separate words
            {
                string theWordAnalyzed = separateWords[i];
                // checking the first character of a word:
                if (theWordAnalyzed[0] >= 'a' && theWordAnalyzed[0] <= 'z')
                {
                    numberOfWordsStartingWithLowercaseLetter++;
                }
            }
            myStats.NumberOfWordsStartingWithSmallLetter = numberOfWordsStartingWithLowercaseLetter;

            // finding the longest word in the document:
            string theLongestWordInDocument = separateWords[0];
            int numberOfCharInLongestWord = separateWords[0].Length;
            for (int i = 0; i < separateWords.Length; i++) // iterating through separate words
            {
                if (separateWords[i].Length > numberOfCharInLongestWord) // true if a longer word was found
                {
                    numberOfCharInLongestWord = separateWords[i].Length; // updating the max character count
                    theLongestWordInDocument = separateWords[i]; // the longest word is updated
                }
            }
            myStats.TheLongestWord = theLongestWordInDocument;

            // finding the shortest word in the document:
            string theShortestWordInDocument = separateWords[0];
            int numberOfCharInShortestWord = separateWords[0].Length;
            for (int i = 0; i < separateWords.Length; i++) // iterating through separate words
            {
                if (separateWords[i].Length < numberOfCharInShortestWord) // true if a shorter word was found
                {
                    numberOfCharInShortestWord = separateWords[i].Length; // updating the min character count
                    theShortestWordInDocument = separateWords[i]; // the shortest word is updated
                }
            }
            myStats.TheShortestWord = theShortestWordInDocument;

            return myStats; // returning the requested Stats class object

        }
    }
}

/*
public class Stats
{
    // Total number of all words in the document
    public int NumberOfAllWords { get; set; }

    // Returns number of words that consist only from digits e.g. 13455, 98374
    public int NumberOfWordsThatContainOnlyDigits { get; set; }

    // Returns number of words that start with a lower letter e.g. a, d, z
    public int NumberOfWordsStartingWithSmallLetter { get; set; }

    // Returns number of words that start with a capital letter e.g. A, D, Z
    public int NumberOfWordsStartingWithCapitalLetter { get; set; }

    // Returns the first longest word in the document
    public string TheLongestWord { get; set; }

    // Returns the first shortest word in the document
    public string TheShortestWord { get; set; }
}
*/




