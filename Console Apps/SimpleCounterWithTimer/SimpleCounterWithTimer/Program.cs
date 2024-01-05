using System.Diagnostics;
using System.Numerics;

int inputNumber = 123456789;
var stopWatch = new Stopwatch();

Console.WriteLine($"Started execution ...");

stopWatch.Start();

BigInteger cumulativeSum = 0;

for (int i = 0; i < inputNumber+1; i++)
{
    cumulativeSum += i;
}

stopWatch.Stop();

Console.WriteLine($"The execution time: {stopWatch.ElapsedMilliseconds} ms.");
Console.WriteLine($"The cumulative sum of all natural numbers from 0 to {inputNumber} (inclusive) is {cumulativeSum}.");
Console.WriteLine($"Mission accomplished!");
