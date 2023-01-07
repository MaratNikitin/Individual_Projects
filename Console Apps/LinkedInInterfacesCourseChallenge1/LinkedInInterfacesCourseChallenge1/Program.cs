/*
This project contains a solution for a challenge from the LinkedIn Learning course "C#: Interfaces and Generics".
The initial task: Build a console app to generate random #s. User enters an upper bound. The result is between 0 
    and the upper bound. No result if input is not a number. Keyword "exit" is used to terminate the app. 
    IRandomizable interface should be implemented. It has one method GetRandomNum taking the upper bound as a 
    parameter and returning a random decimal number. And the custom class implements this interface.
When: January 2023.
Author: Marat Nikitin. 
 */


public interface IRandomizable
{
    decimal GetRandomNum(int upperLimitNumber);
};

public class RandomGenerator : IRandomizable
{
    public RandomGenerator()
    {
        // Empty constructor 
    }
    public decimal GetRandomNum(int upperLimitNumber)
    {
        var random = new Random();
        return (decimal)random.NextDouble()*upperLimitNumber;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        while (true) // it's an infinite loop where entering "exit" as a user input will stop the execution
        {
            Console.WriteLine("Please enter the upper boundary number (a positive integer): ");
            string userInputString = Console.ReadLine() ?? "";

            if (userInputString.ToUpper().Contains("EXIT")) // making it case insensitive
            {
               Environment.Exit(0); // stops the execution of the application
            }

            int upperBoundaryNumber;

            try
            {
                upperBoundaryNumber = int.Parse(userInputString);
            }
            catch
            { // it means that the input could not be parsed into an integer
                Console.WriteLine("Sorry, it's not an integer number.");
                Console.WriteLine();
                continue;
            }    
            
            RandomGenerator rg = new();
            decimal randomNumber = rg.GetRandomNum(upperBoundaryNumber);

            Console.WriteLine($"Random number between 0 and {upperBoundaryNumber}: {randomNumber}");
            Console.WriteLine();
        }

    }
}