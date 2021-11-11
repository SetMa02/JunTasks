using System;
using System.Linq;

namespace LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] arr = Enumerable.Repeat(0, 30).Select(x => x = rnd.Next(0, 10)).ToArray();

            for (int i = 0; i < arr.Length; i++) 
                Console.Write(arr[i] + " ");
            Console.WriteLine();

            if (arr[0] > arr[1])
            {
                Console.Write(arr[0]);
                Console.Write("  ");
            }
            else
                Console.Write("  ");
            
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                    Console.Write(arr[i] + " ");
                else
                    Console.Write("  ");
            }
            
            if(arr[arr.Length] > arr[arr.Length - 1])
                Console.Write(arr[arr.Length]);
            else
                Console.Write("  ");
                
            Console.ReadKey();
        }
    }
}