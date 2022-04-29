using System;

namespace RandomSumm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxNumber = 100;
            int minNumber = 0;
            int firstDeleteNumber = 3;
            int secondDeleteNumber = 5;
            int randomNumber = random.Next(minNumber, maxNumber);
            int summ = 0;
            
            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % firstDeleteNumber == 0 || i % secondDeleteNumber == 0)
                {
                    summ += i;
                }
            }
            
            Console.WriteLine(summ);
        }
    }
}