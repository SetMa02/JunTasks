using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffle
{
    class Program
    {
        private static void Main(string[] args)
        {
            var digits = new[] { 1, 22, 3, 4, 5, 9, 8, 24, 38, 1, 54, 63, 2 };
            Shuffle(digits);
            Console.WriteLine(string.Join(" ", digits));
            Console.ReadKey();
        }
        
        private static void Shuffle<T>(IList<T> array)
        {
            Random random = new Random();
            for(int i = 0; i < 100; i++)
            {
                var rndInd = random.Next(0, array.Count());
                var rndInd2 = random.Next(0, array.Count());
                var temp = array[rndInd];
                array[rndInd] = array[rndInd2];
                array[rndInd2] = temp;
            }
        }
    }
}