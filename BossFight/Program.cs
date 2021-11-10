using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int healthBoss = 1000;
            int damageBoss = random.Next(30, 85);

            int healthPlayer = 500;
            int manaPlayer = 200;

            bool enableGame = true;
            string enterSpell;

            Console.WriteLine(
                "Передвами стоит огромный ДедИнсайд он настроен агресивно избежать драки не возможно приготовтесь к битве. \n Ваши доступные заклинания: \n" +
                "1) sunlight - Ослеплеющий свет, станит противника на 2 хода, отнимает 30 едениц маны.\n" +
                "2) meditation - Востанавливает игроку 100 ХП и 50 единиц маны, игрок не может применять атакующие спелы 1 ход\n" +
                "3) lightningstrike - Удар молнией наносит 100 урона, пробуждает ослепленного врага, отнимает 45 едениц маны.\n" +
                "4) toxicsmoke - Создается ядовитое облако и наносит 20 урона или, если враг ослеплен 50, в течении 5ти ходов, отнимает 60 единиц маны.\n");

            while (enableGame)
            {
                
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Введите заклинание:");
            switch (Console.ReadLine())
            {
                case "sunlight":
                    break;
                case "meditation":
                    break;
                case "lightningstrike":
                    break;
                case "toxicsmole":
                    break;
                default:
                    break;
            }
        }

        private void SunLight()
        {
            PlayerTurn();
            PlayerTurn();
        }
    }
}