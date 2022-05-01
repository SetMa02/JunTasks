using System;
using System.Collections.Generic;

namespace Skobkochki
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input.Length == 0){
                Console.WriteLine("Ошибка!");
                return;
            }
            var skobki = 0;
            var count = 0;
            var list = new List<int>();
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    skobki++;
                }
                else if (input[i] == ')')
                {
                    if ( i != input.Length-1 && input[i+1] != '(' )
                        count++;
                    skobki--;
                }
                if (skobki== 0)
                {
                    list.Add(count);
                    count = 0;
                }
            }
            list.Sort();
            
            if (skobki == 0)
            {
                Console.WriteLine(list[list.Count - 1] + 1);
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}