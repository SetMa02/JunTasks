using System;

namespace CommandApplicarion
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeCommand = "[Time] - Узнать время";
            string summCommand = "[Sum] - Суммировать числа";
            string colorCommand = "[ChangeColor] - Раскрасить консоль";
            string exitCommand = "[Esc] - Выход";

            string answer = "";

            while (answer != "Esc")
            {
                Console.Clear();
                Console.WriteLine("МЕНЮ:");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::");
                Console.WriteLine(timeCommand);
                Console.WriteLine(summCommand);
                Console.WriteLine(colorCommand);
                Console.WriteLine(exitCommand);
                Console.WriteLine("::::::::::::::::::::::::::::::::::::\n");
                Console.Write("Введите команду из пункта меню: ");
                answer = Console.ReadLine();

                if (answer == "Time")
                {
                    Console.Clear();
                    Console.WriteLine(timeCommand);
                    Console.WriteLine(DateTime.Now);
                    Console.Write("\nНажмите Enter для возврата в меню...");
                    Console.ReadLine();
                }
                else if (answer == "Sum")
                {
                    Console.Clear();
                    Console.WriteLine(summCommand);
                    Console.Write("\nВведите первое число: ");
                    int numOne = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    int numTwo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nСумма чисел {0} и {1} равняется {2}.\n", numOne, numTwo, numOne + numTwo);
                    Console.Write("\nНажмите Enter для возврата в меню...");
                    Console.ReadLine();
                }
                else if (answer == "ChangeColor")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(colorCommand);
                    Console.WriteLine("\nПроизведена окраска фона.");
                    Console.Write("\nНажмите Enter для возврата в меню...");
                    Console.ReadLine();
                    Console.ResetColor();
                }
                else if (answer == "Esc")
                {
                    Console.Clear();
                    Console.WriteLine(exitCommand);
                    Console.Write("\nБлагодарим за использование нашего продукта!");
                }
                else
                    Console.WriteLine("Неверная команда, повторите ввод.");

                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}