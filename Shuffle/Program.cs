using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffle
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] digits = new int[] { 1, 22, 3, 4, 5, 9, 8, 24, 38, 1, 54, 63, 2 };
            Shuffle(digits);
            Console.WriteLine(string.Join(" ", digits));
            Console.ReadKey();
        }
        
        private static void Shuffle(int [] array)
        {
            Random random = new Random();
            for(int i = 0; i < 100; i++)
            {
                int rndInd = random.Next(0, array.Count());
                int rndInd2 = random.Next(0, array.Count());
                int temp = array[rndInd];
                array[rndInd] = array[rndInd2];
                array[rndInd2] = temp;
            }
        }
    }
}