using System;

namespace SwitchVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string secondName;
            string buffer;
            
            Console.WriteLine("Введите имя");
            secondName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            firstName = Console.ReadLine();

            buffer = secondName;
            secondName = firstName;
            firstName = buffer;
            
            Console.WriteLine($"Имя - {firstName}, Фамилия - {secondName}");
        }
    }
}