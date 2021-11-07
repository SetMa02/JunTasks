using System;

namespace z1
{
    class Program
    {
        static void Main(string[] args)
        {
            int photos = 52;
            int countAtOneRow = 3;

            int rowsCount = photos / countAtOneRow;
            int overflowCount = photos % countAtOneRow;

            Console.WriteLine("Заполнится рядов - " + rowsCount);
            Console.WriteLine("Картинок сверх меры - " + overflowCount);
            
            Console.ReadLine();
        }
    }
}