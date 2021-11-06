using System;

namespace GoldForCrystals
{
    class Program
    {
        static void Main(string[] args)
        {
            int goldsCount = 0;
            int cristalsCount = 0;
            int priceCristal = 3;

            Console.Write("Введите ваше количество золота: ");
            goldsCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Цена за 1 кристалл - " + priceCristal);
            Console.WriteLine("Сколько кристаллов вы хотите купить?");
            cristalsCount = Convert.ToInt32(Console.ReadLine());

            goldsCount -= (cristalsCount * priceCristal);

            Console.WriteLine();
            Console.WriteLine("Вы приобрели кристаллов в кол-ве: " + cristalsCount);
            Console.WriteLine("Остаток золота: " + goldsCount);
        }
    }
}