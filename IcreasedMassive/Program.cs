using System;
using System.Linq;

namespace IcreasedMassive
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[0];
            double arraySum = 0;
            bool exit = false;
            
            Console.WriteLine("Команды: sum - сумма | exit- выход");
            while (!exit)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                if (input == "sum")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine("Сумма: " + arraySum);
                }
                else if (input.ToLower() == "amount")
                {
                    Console.WriteLine(array.Sum());
                    double[] arrayClear = new double[0];
                    array = arrayClear;
                }
                else if (input.ToLower() == "exit")
                {
                    exit = true;
                }
                else if (double.TryParse(input, out double number))
                {
                    double[] tempArray = new double[array.Length + 1];
                    tempArray[tempArray.Length - 1] = double.Parse(input);
                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }

                    array = tempArray;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
        }
    }
}