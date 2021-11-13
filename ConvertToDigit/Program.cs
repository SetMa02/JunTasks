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
            
            ConvertToInt(out convertedDigit);
            
            Console.WriteLine(convertedDigit);
        }

        public static void ConvertToInt(out int Digit)
        {
            bool isExit = false;
            int inputDigit = 0;
            
            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Введите число: ");

                isExit = Int32.TryParse(Console.ReadLine(), out inputDigit);
                
            }

            Digit = inputDigit;
        }
    }
}