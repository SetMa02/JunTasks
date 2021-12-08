using System;
using System.Linq;

namespace LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = Enumerable.Repeat(0, 30).Select(x => x = random.Next(0, 10)).ToArray();

            for (int i = 0; i < array.Length; i++) 
                Console.Write(array[i] + " ");
            Console.WriteLine();

            if (array[0] > array[1])
                Console.Write(array[0]);
            
            for (int i = 1; i <= array.Length -1 ; i++)
            {
                if (i == array.Length - 1)
                {
                    if (array[array.Length - 2] < array[array.Length - 1])
                    {
                        Console.Write(array[i] + "   ");
                    }
                }
                else
                {
                    if (array[i] > array[i - 1] && array[i] > array[i+1])
                        Console.Write(array[i] + " ");
                    else
                        Console.Write("  ");
                }
                
            }
            
          
            
                
            Console.ReadKey();
        }
    }
}