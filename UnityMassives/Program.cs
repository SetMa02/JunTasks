using System;
using System.Collections.Generic;

namespace UnityMassives
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massive1 = new int[] { 2, 1, 3 };
            int[] massive2 = new int[] { 3, 4, 5 ,4,5,5,5};
            int buffer = 0;
            int deleteindexOffset = 1;

            List<int> unitedMassive = new List<int>();
            List<int> deleteIndexes = new List<int>();

            foreach (var number in massive1)
            {
                unitedMassive.Add(number);
            }

            foreach (var number in massive2)
            {
                unitedMassive.Add(number);
            }
                
            unitedMassive.Sort();
            
            foreach (var number in unitedMassive)
            {
                if (number == buffer)
                {
                    deleteIndexes.Add(unitedMassive.IndexOf(number));
                }
                buffer = number;
            }

            foreach (var delete in deleteIndexes)
            {
                if (deleteIndexes.IndexOf(delete) == 0)
                {
                    unitedMassive.RemoveAt(delete);
                }
                else
                {
                    unitedMassive.RemoveAt(delete-deleteindexOffset);
                }
            }

            foreach (var number in unitedMassive)
            {
                Console.Write(number+ " ");
            }
        }
    }
}