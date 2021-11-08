using System;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = "SECRET MESSAGE IS HERE!@!#$@";
            string password = "junior";
            string userInputPassword;
            int countOfTrys = 3;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Введите пароль:");
                userInputPassword = Console.ReadLine();
                if (userInputPassword == password)
                {

                    Console.WriteLine("\nДоступ разрешен: \n");
                    Console.WriteLine(secretMessage);
                    isExit = true;
                }
                else if (userInputPassword == "exit")
                {
                    isExit = true;
                }
                else
                {
                    countOfTrys-- ;
                    if (countOfTrys == 0)
                    {
                        Console.WriteLine("Доступ зепрещен");
                        isExit = true;
                    }
                    Console.WriteLine($"у вас осталось {countOfTrys} попыток в запасе");
                }
            }
        }
    }
}