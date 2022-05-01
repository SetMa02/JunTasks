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
            int increeseStepen = 2;
            int number = random.Next(minNumber, maxNumber);

            while (number > result)
            {
                result *= increeseStepen;
                stepen++;
            }
            
            Console.Write($"{number}, {stepen}, {result}");
        }
    }
}