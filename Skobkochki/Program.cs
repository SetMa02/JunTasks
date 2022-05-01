using System;
using System.Collections.Generic;

namespace Skobkochki
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            if (input.Length == 0){
                Console.WriteLine("Ошибка!");
                return;
            }
            int hooksCount = 0;
            int count = 0;
            int totalHooks = 0;
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    hooksCount++;
                }
                else if (input[i] == ')')
                {
                    if ( i != input.Length-1 && input[i+1] != '(' )
                        count++;
                    hooksCount--;
                }
                if (hooksCount== 0)
                {
                    totalHooks++;
                    count = 0;
                }
            }

            if (hooksCount == 0)
            {
                Console.WriteLine(totalHooks);
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}