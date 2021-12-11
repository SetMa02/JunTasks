using System;
using System.Collections.Generic;

namespace DictionaryDocie
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> employees = new Dictionary<string, string>();
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

        static void AddEmployee(Dictionary<string, string> employees)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО работника: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string work = Console.ReadLine();
            employees.Add(fio, work);
        }

        static void ShowAllEmployees(Dictionary<string, string> employees)
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("Выводить нечего!");
                return;
            }

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Key +" - "+ employee.Value);
            }
        }

        private static void DeleteEmployee(Dictionary<string, string> employees)
        {   
            Console.Clear();

            if (employees.Count == 0)
            {
                Console.WriteLine("Удалять нечего!");
                return;
            }

            int deleteIndex;
            int employeeIndex = 1;
            foreach (var employee in employees)
            {
                Console.WriteLine(employeeIndex+". " + employee.Key +" - "+ employee.Key);
                employeeIndex++;
            }
            Console.WriteLine("Введите индекс на удаление:");

            if (Int32.TryParse(Console.ReadLine(), out deleteIndex))
            {
                employeeIndex = 1;
                foreach (var employee in employees)
                {
                    employeeIndex++;
                    if (deleteIndex + 1 == employeeIndex)
                    {
                        employees.Remove(employee.Key);
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс!");
            }
        }
    }
}