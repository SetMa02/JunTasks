using System;

namespace Stepen2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int result = 1;
            int stepen = 0;
            int minNumber = 4;
            int maxNumber = 100;
            int number = random.Next(minNumber, maxNumber);

            while (number > result)
            {
                result *= 2;
                stepen++;
            }
            
            Console.Write($"{number}, {stepen}, {result}");
        }
    }
}