using System;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new [] {5, 6, 1, 8, 3, 2, 9, 11, -7, -50};
            int buffer;
            int index; 
            
            for (int i = 0; i < numbers.Length; i++) 
            {
                index = i; 
                for (int j = i; j < numbers.Length; j++) 
                {
                    if (numbers[j] < numbers[index])  
                    {
                        index = j; 
                    }
                }

                if (numbers[index] != numbers[i])
                {
                    buffer= numbers[i]; 
                    numbers[i] = numbers[index];
                    numbers[index] = buffer;
                }
            }
            
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}