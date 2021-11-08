using System;

namespace z1
{
    class Program
    {
        static void Main(string[] args)
        {
            int photos = 52;
            int photosAtRow = 3;

            int photoRowsCount = photos / photosAtRow;
            int overflowPhotoCount = photos % photosAtRow;

            Console.WriteLine("Заполнится рядов - " + photoRowsCount);
            Console.WriteLine("Картинок сверх меры - " + overflowPhotoCount);
            
            Console.ReadLine();
        }
    }
}