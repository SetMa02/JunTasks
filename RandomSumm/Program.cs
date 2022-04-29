using System;

namespace RandomSumm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            int summ = 0;
            
            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    summ += i;
                }
            }
            
            Console.WriteLine(summ);
        }
    }
}