using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ConvertToDigit
{
    class Program
    {
   
        static void Main(string[] args)
        {
            bool isExit = false;
            int convertedDigit;
            while (isExit == false)
            {
               
                Console.WriteLine("Введите число: ");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    return;
                }
                convertedDigit = ConvertToInt(input);
                Console.WriteLine(convertedDigit);
            }
        }

        public static int ConvertToInt(string input)
        {
            int outputDigit;
            if (!Int32.TryParse(input, out outputDigit))
            {
                 Console.WriteLine("Преобразование не произошло");   
            }
            return outputDigit;
        }
    }
}