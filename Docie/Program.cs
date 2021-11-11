using System;
using System.Linq;

namespace Docie
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fioTable = new string[] { };
            string[] workTable = new string[] { };
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("1 - Добавить сотрудника \n" +
                                  "2 - Удалить сотрудника \n" +
                                  "3 - Просмотр сотрудников \n" +
                                  "4 - Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddEmployee(ref fioTable, ref workTable);
                        break;
                    case "2":
                        DeleteEmployee(ref fioTable, ref workTable);
                        break;
                    case "3":
                        ShowEmploee(ref fioTable, ref workTable);
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод!!!");
                        break;
                }
            }
        }

        public static void AddEmployee(ref string[] fio, ref string[] work)
        {
            Console.Clear();
            Console.Write("Введите ФИО сотрудника - ");
            Array.Resize(ref fio, fio.Length + 1);
            fio[fio.Length - 1] = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Введите должность - ");
            Array.Resize(ref work, work.Length + 1);
            work[work.Length - 1] = Console.ReadLine();
        }

        public static void DeleteEmployee(ref string[] fio, ref string[] work)
        {
            Console.Clear();
            Console.WriteLine("Какого сотрудника удалить?");
            for (int i = 0; i < fio.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + fio[i] + " - " + work[i]);
            }

            int indexToRemove = Convert.ToInt32(Console.ReadLine());
            var fioList = fio.ToList();
            var workList = work.ToList();
            
            workList.RemoveAt(indexToRemove - 1);
            fioList.RemoveAt(indexToRemove - 1);
            
            fio = fioList.ToArray();
            work = workList.ToArray();
        }

        public static void ShowEmploee(ref string[] fio, ref string[] work)
        {
            Console.Clear();
            for (int i = 0; i < fio.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + fio[i] + " - " + work[i]);
            }

            Console.WriteLine();
        }
    }
}