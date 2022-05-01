using System;

namespace Stepen2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int result = 1;
            int degree = 0;
            int minNumber = 4;
            int maxNumber = 100;
            int numberOfBase = 2;
            int number = random.Next(minNumber, maxNumber);

            while (number > result)
            {
                result *= numberOfBase;
                degree++;
            }
            
            Console.Write($"{number}, {degree}, {result}");
        }
    }
}