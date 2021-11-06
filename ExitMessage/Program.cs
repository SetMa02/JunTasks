using System;

namespace ExitMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            while (isExit == false)
            {
                Console.WriteLine("Введите сообщение:");
                if (Console.ReadLine() == "exit")
                {
                    isExit = true;
                }
            }
        }
    }
}