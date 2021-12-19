using System;
using System.Collections.Generic;

namespace DictionaryDocie
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            bool isExit = false;
            while (isExit == false)
            {
                Console.WriteLine();
                Console.WriteLine("1 - добавить сотрудника \n" +
                                  "2 - показать всех сотрудников \n" +
                                  "3 - удалить сотрудника \n" +
                                  "4 - выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddEmployee(employees);
                        break;
                    case "2":
                        ShowAllEmployees(employees);
                        break;
                    case "3":
                        DeleteEmployee(employees);
                        break;
                    case "4":
                        isExit = true;
                        break; 
                    default:
                        Console.WriteLine("Невверный ввод!");    
                        break;
                }
            }
        }

        static void AddEmployee(Dictionary<int, string> employees)
        {
            Console.Clear();
            int indexofEmployee = GetLastIndex(employees) + 1;
            Console.WriteLine("Введите ФИО работника: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string work = Console.ReadLine();
            employees.Add(indexofEmployee, name + " - " + work);
        }

        static void ShowAllEmployees(Dictionary<int, string> employees)
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("Выводить нечего!");
                return;
            }

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Key +". "+ employee.Value);
            }
        }

        private static void DeleteEmployee(Dictionary<int, string> employees)
        {   
            Console.Clear();

            if (employees.Count == 0)
            {
                Console.WriteLine("Удалять нечего!");
                return;
            }

            string deleteIndex;
            foreach (var employee in employees)
            {
                Console.WriteLine( employee.Key +". "+ employee.Value);
            }
            Console.WriteLine("Введите индекс на удаление:");

            deleteIndex = Console.ReadLine();
            try
            {
                employees.Remove(Int32.Parse(deleteIndex));
            }
            catch (Exception e)
            {
                Console.WriteLine("Неверный индекс!");
            }
        }

        static int GetLastIndex(Dictionary<int, string> employees)
        {
            int lastIndex = 0;
            foreach (var employee in employees)
            {
                lastIndex = employee.Key;
            }

            return lastIndex;
        }
    }
}