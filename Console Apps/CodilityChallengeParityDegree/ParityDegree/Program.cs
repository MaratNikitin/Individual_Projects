using System.Numerics;

int GetHighestPowerOfTwoDivider(int N)
{
    var power = 0;
    int modulo = 0;

    while(modulo == 0)
    {
        power++;
        modulo = N % (int)Math.Pow(2, power);
    }

    return --power;
}

var inputNumber = 1;
Console.WriteLine($"For N = {inputNumber} the highest power of 2 that divides N is {GetHighestPowerOfTwoDivider(inputNumber)}");
