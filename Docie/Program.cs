using System;
using System.Linq;

namespace Docie
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] employeesTable = new string[] { };
            string[] worksTable = new string[] { };
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("1 - Добавить сотрудника \n" +
                                  "2 - Удалить сотрудника \n" +
                                  "3 - Просмотр сотрудников \n" +
                                  "4 - Поиск сотрудника \n" +
                                  "5 - Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddEmployee(ref employeesTable, ref worksTable);
                        break;
                    case "2":
                        DeleteEmployee(ref employeesTable, ref worksTable);
                        break;
                    case "3":
                        ShowEmploee(employeesTable, worksTable);
                        break;
                    case "4":
                        FindEmployee(employeesTable, worksTable);
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод!!!");
                        break;
                }
            }
        }

        public static void FindEmployee(string[] employee, string[] works)
        {
            if (employee.Length == 0)
            {
                Console.WriteLine("Искать нечего!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Введите фамилию сотрудника: ");
            string searchEmployee = Console.ReadLine();

            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i] == searchEmployee)
                {
                    Console.WriteLine(i + 1 + ". " + employee[i] + " - " + works[i]);
                }
            }
        }

        public static void AddEmployee(ref string[] employee, ref string[] works)
        {
            Console.Clear();
            Console.Write("Введите ФИО сотрудника - ");
            Array.Resize(ref employee, employee.Length + 1);
            employee[employee.Length - 1] = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Введите должность - ");
            Array.Resize(ref works, works.Length + 1);
            works[works.Length - 1] = Console.ReadLine();
        }

        public static void DeleteEmployee(ref string[] employee, ref string[] works)
        {
            if (employee.Length == 0)
            {
                Console.WriteLine("Удалять нечего!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Введите номер сотрудника на удаление:");
            for (int i = 0; i < employee.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + employee[i] + " - " + works[i]);
            }

            int indexToDelete = Convert.ToInt32(Console.ReadLine());

            string[] newEmployees = new string[employee.Length-1];
            string[] newWorks = new string[employee.Length-1];

            for (int i = 0; i < employee.Length-1; i++)
            {
                if (i == indexToDelete - 1)
                {
                }
                else
                {
                    newEmployees[i] = employee[i];
                    newWorks[i] = works[i];
                }
            }
            employee = newEmployees;
            works = newWorks;
        }

        public static void ShowEmploee(string[] employee, string[] works)
        {
            if (employee.Length == 0)
            {
                Console.WriteLine("Показывать нечего!");
                return;
            }

            Console.Clear();
            for (int i = 0; i < employee.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + employee[i] + " - " + works[i]);
            }

            Console.WriteLine();
        }

        public static void RemoveAt<T>(ref T[] arrAy, int index)
        {
            for (int i = index; i < arrAy.Length - 1; i++)
            {
                arrAy[i] = arrAy[i + 1];
            }

            Array.Resize(ref arrAy, arrAy.Length - 1);
        }
    }
}