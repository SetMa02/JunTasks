using System;
using System.Collections.Generic;
using System.Linq;

namespace ListSumm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfDigits = new List<int>();
            bool isExit = false;
            int sum;
            while (isExit == false)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "sum":
                        sum = listOfDigits.ToArray().Sum();
                        Console.WriteLine("Сумма: " + sum);
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        listOfDigits.Add(Convert.ToInt32(input));
                        break;
                }
            }
        }
    }
}