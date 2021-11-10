using System;

namespace MatrixTom10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            int max = 0;
            int buffI = 0;
            int buffj = 0;
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-100, 100);
                    Console.Write( matrix[i, j] +" ");
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        buffI = i;
                        buffj = j;
                    }
                }
                Console.WriteLine();
            }

            matrix[buffI, buffj] = 0;
            Console.WriteLine("======================================");
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write( matrix[i, j] +" ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine(max + " - наибольшее число");

        }
    }
}