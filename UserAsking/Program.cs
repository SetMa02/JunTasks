using System;

namespace UserAsking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Как вас зовут ");
            string name = Console.ReadLine();
            Console.Write("Сколько вам лет? ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какой ваш знак зодиака ");
            string zodiacSign = Console.ReadLine();
            Console.Write("Ваше место работы ");
            string placeOfWork = Console.ReadLine();
            Console.WriteLine($"Вас зовут {name}, вам {age} год, вы {zodiacSign} и работаете на {placeOfWork}.");
        }
    }
}