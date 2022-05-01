using System;

namespace N127
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int firstNumber = 1;
            int lastNumber = 27;
            int number = random.Next(firstNumber, lastNumber);
            int count = 0;
            int minNumber = 99;
            int maxNumber = 1000;

            for (int i = number; i < maxNumber; i += number)
            {
                if (i > minNumber)
                {
                    count++;
                }
            }
    
            Console.WriteLine("Результат: {0}", count);
        }
    }
}