using System;

namespace StringSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            string[] massive;
            
            Console.WriteLine("Введите текст:");

            text = Console.ReadLine();

            massive = text.Split(" ");

            foreach (var word in massive)
            {
                Console.WriteLine(word);
            }
        }
    }
}