using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ConvertToDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int convertedDigit;
            convertedDigit = ConvertUserInputToInt();
            Console.WriteLine(convertedDigit);
        }

        public static int ConvertUserInputToInt()
        {
            int outputDigit = 0;
            bool isExit = false;
            string input;
            while (isExit == false)
            {
                Console.WriteLine("Введите число: ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out outputDigit))
                {
                    Console.WriteLine("Преобразование не произошло");
                }
                else
                {
                    isExit = true;
                }
            }

            return outputDigit;
        }
    }
}