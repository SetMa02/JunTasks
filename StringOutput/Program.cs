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
            string sumbol = Console.ReadLine();

            int wordLengh = word.Length;

            for (int i = 1; i <= 3; i++)
            {
                if (i == 1)
                {
                    for (int b = 1; b <= wordLengh + 2; b++)
                    {
                        Console.Write(sumbol);
                    }
                }
                else if (i == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine(sumbol + word + sumbol);
                }
                else if (i == 3)
                {
                    for (int b = 1; b <= wordLengh + 2; b++)
                    {
                        Console.Write(sumbol);
                    }
                }                        
             
            }
        }
    }
}