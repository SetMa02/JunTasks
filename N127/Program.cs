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
            int minNumber = 100;
            int maxNumber = 1000;
            
            for(int i = minNumber; i < maxNumber; ++i)
            {
                string newNumber = i.ToString();
        
                if(int.Parse(newNumber[0].ToString()) + int.Parse(newNumber[1].ToString()) + int.Parse(newNumber[2].ToString()) == number)
                {
                    count++;
                }
            }
    
            Console.WriteLine("Результат: {0}", count);
        }
    }
}