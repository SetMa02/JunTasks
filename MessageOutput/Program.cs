using System;

namespace MessageOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение: ");
            string message = Console.ReadLine();
            Console.WriteLine("Введите количество повторений: ");
            int count = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }

            Console.ReadKey();
        }
    }
}