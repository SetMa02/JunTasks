using System;

namespace Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Использую цикл FOR потомучто есть четкое обозначения конца цикла. While удобен бля бесконечного цикла. foreach для массивов*/

            int maxValue = 98;
            int step = 7;
            int firstChar = 7;
            
            for (int i = firstChar; i <= maxValue; i += step)
            {
                Console.Write(i + " ");
            }
        }
    }
}