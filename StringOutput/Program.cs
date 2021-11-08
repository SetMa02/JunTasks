using System;

namespace StringOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string word = Console.ReadLine();
            Console.WriteLine("Введите символ:");
            string symbol = Console.ReadLine();

            int wordLengh = word.Length;
            
            for (int b = 1; b <= wordLengh + 2; b++)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine(symbol + word + symbol);
            
            for (int b = 1; b <= wordLengh + 2; b++)
            {
                Console.Write(symbol);
            }
        }
    }
}