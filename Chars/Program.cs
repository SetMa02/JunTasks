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
            
            for (int i = 7; i <= maxValue; i = i + 7)
            {
                Console.Write(i + " ");
            }
        }
    }
}