using System;

namespace SecSumm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] massive = new int[3, 3];
            int secondSumm = 0;
            int firstProizv = 1;
            Random random = new Random();

            for (int i = 0; i < massive.GetLength(0); i++)
            {
                for (int j = 0; j < massive.GetLength(1); j++)
                {
                    massive[i, j] = random.Next(0, 100);
                    Console.Write(massive[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("=========");


            for (int j = 0; j < massive.GetLength(1); j++)
            {
                secondSumm += massive[1, j];
            }
            
            for (int j = 0; j < massive.GetLength(1); j++)
            {
                firstProizv *= massive[j, 0];
            }

            Console.WriteLine(firstProizv + " - Произведение первого столбца");
            Console.WriteLine(secondSumm + " - Сумма второй строки");
        }
    }
}