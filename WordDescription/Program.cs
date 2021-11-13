using System;
using System.Collections.Generic;

namespace WordDescription
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            
            items.Add("стул", "Стульчкик посидеть.");
            items.Add("стол", "стол кухонный, хороший.");
            items.Add("холодильник", "Самый лучший предмет.");
            items.Add("телевизор", "Кго уже давно не смотрят.");
            
            string userInput;

            bool isExit = false;
 
            while (isExit == false)
            {
                Console.Write("Введите название предмета: ");
                userInput = Console.ReadLine();
 
                if (items.ContainsKey(userInput.ToLower()))
                    Console.WriteLine(items[userInput]);
                else
                    Console.WriteLine("Нераспознал");
                if (userInput == "exit")
                    isExit = true;

            }
        }
    }
}