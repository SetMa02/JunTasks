using System;

namespace UnderMassive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massive = new int[]{1,1,1,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,5,5,5,5,6,6,6,7,7,7,7,8,8,9,9};
            int bestRow=0;
            int currentRow=0;
            int bestNumber=0;
            int currentNumber=0;
            int rowStartNumber = 1;

            foreach (var number in massive)
            {
                if (number != currentNumber)
                {
                    currentNumber = number;
                    currentRow = rowStartNumber;
                }
                else
                {
                    if (currentNumber == bestNumber)
                    {
                        bestNumber++;
                    }
                    currentRow++;
                    
                    if (currentRow > bestRow && currentNumber != bestNumber)
                    {
                        bestRow = currentRow;
                        bestNumber = currentNumber;
                    }
                }
            }
            Console.WriteLine($"Больший подмассим - {bestNumber}, длинной {bestRow}");
        }
    }
}