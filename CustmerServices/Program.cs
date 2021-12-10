using System;
using System.Collections.Generic;

namespace CustmerServices
{
    class Program
    {
        static void Main(string[] args)
        {
            int qoueLength = 10;
            int userWallet = 0;
            Dictionary<int, int> customers = new Dictionary<int, int>();
            
            Random random = new Random();

            for (int i = 1; i <= qoueLength; i++)
            {
                customers.Add(i,random.Next(10, 50000));
            }

            for (int i = 1; i <= qoueLength; i++)
            {
                Console.WriteLine("Ваши денежки: " +userWallet);
                ServicingCustomer(ref customers, i, ref userWallet);
            }
        }

        private static void ServicingCustomer(ref Dictionary<int, int> customers, int currentCustomer, ref int wallet)
        {
            Console.WriteLine("Покуавтель № " + currentCustomer + " С покупками на сумму - "  + customers[currentCustomer]);
            Console.WriteLine("Нажмите любую кнопку чтобы обслужить");
            Console.ReadKey();
            wallet += customers[currentCustomer];
            Console.Clear();
        }
    }
}