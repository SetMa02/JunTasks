using System;
using System.Collections.Generic;

namespace DictionaryDocie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> employees = new List<string>();
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

        static void AddEmployee(List<string> employees)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО работника: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string work = Console.ReadLine();
            employees.Add( name + " - " + work);
        }

        static void ShowAllEmployees(List<string> employees)
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("Выводить нечего!");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(i +". "+ employees[i]);
            }
        }

        private static void DeleteEmployee(List<string> employees)
        {   
            string deleteIndexInput;
            int deleteIndex;
            
            Console.Clear();

            if (employees.Count == 0)
            {
                Console.WriteLine("Удалять нечего!");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(i +". "+ employees[i]);
            }
            Console.WriteLine("Введите индекс на удаление:");

            deleteIndexInput = Console.ReadLine();
            if (Int32.TryParse(deleteIndexInput,out deleteIndex))
            {
                employees.RemoveAt(deleteIndex);
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}