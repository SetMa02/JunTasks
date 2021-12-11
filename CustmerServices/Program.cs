using System;
using System.Collections.Generic;

namespace CustmerServices
{
    class Program
    {
        static void Main(string[] args)
        {
            int queueLength = 10;
            int userWallet = 0;
            Queue<int> customers = new Queue<int>();
            
            Random random = new Random();

            for (int i = 1; i <= queueLength; i++)
            {
                customers.Enqueue(random.Next(50,2000));
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("Ваши денежки: " +userWallet);
                userWallet += ServiceCustomer(customer);
            }
            
        }

        private static int ServiceCustomer(int customer)
        {
            Console.WriteLine(" С покупками на сумму - "  + customer);
            Console.WriteLine("Нажмите любую кнопку чтобы обслужить");
            Console.ReadKey();
            Console.Clear();
            return customer;
        }
    }
}