using System;

namespace SdvigMassive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massive;
            int massiveLength;
            int moveCount;
            int buffer1 = 0;
            int buffer2 = 0;
            int currentId;
            int targetId;
            int dubbleFix = 1;
            
            Console.WriteLine("Введите длину массива:");
            if (Int32.TryParse(Console.ReadLine(), out massiveLength))
            {
                massive = new int[massiveLength];

                Console.WriteLine("Исходный массив:");
                
                for (int i = 0; i < massive.Length; i++)
                {
                    massive[i] = i + 1;
                    Console.Write(massive[i] + " ");
                }
                Console.WriteLine("\nВведите сдвиг");

                if (Int32.TryParse(Console.ReadLine(), out moveCount))
                {
                    for (int i = 0; i < moveCount; i++)
                    {
                        for (int j = massive.Length; j > 0; j--)
                        {
                            targetId = j-1;
                            currentId = j;
                            
                            if (currentId >= massive.Length)
                            {
                                currentId = 0;
                            }
                            
                            if (targetId < 0)
                            {
                                targetId = massive.Length;
                            }

                            if (buffer1 == 0)
                            {
                                buffer1 = massive[targetId];

                                massive[targetId] = massive[currentId];
                            }
                            else
                            {
                                buffer2 = massive[targetId];
                                massive[targetId] = buffer1;
                                buffer1 = buffer2;
                            }

                            if (massive[targetId] == massive[currentId])
                            {
                                massive[currentId] = massive[targetId]+dubbleFix;
                            }
                        }
                    }
                }
                Console.WriteLine();

                foreach (var number in massive)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}