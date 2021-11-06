using System;

namespace z1
{
    class Program
    {
        static void Main(string[] args)
        {
            int photos = 52;
            int countAtoneRow = 3;

            int rowsCount = photos / countAtoneRow;
            int overflowCount = photos % countAtoneRow;

            Console.WriteLine("Заполнится рядов - " + rowsCount);
            Console.WriteLine("Картинок сверх меры - " + overflowCount);


            Console.ReadLine();
        }
    }
}