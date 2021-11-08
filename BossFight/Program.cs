using System;
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
                "Передвами стоит огромный огр он настроен агресивно избежать драки не возможно приготовтесь к бою. \n Ваши доступные заклинания: \n" +
                "1) fireball - Огненый шар наносит 50 урона, отнимает 30 едениц маны.\n" +
                "2) sourcelife - Востанавливает игроку по 20 ХП в течении 3 секунд урон босса не проходит, отнимает 50 единиц маны.\n" +
                "3) lightningstrike - Удар молнией наносит 100 урона, отнимает 45 едениц маны.\n" +
                "4) toxicsmoke - Создается ядовитое облако и наносит 20 урона в течении 3 секунд, отнимает 60 единиц маны.\n");

            while (enableGame)
            {
                if (healthBoss <= 0)
                {
                    Console.WriteLine("Босс Сдох!");
                    enableGame = false;
                }
                else if (healthPlayer <= 0)
                {
                    Console.WriteLine("Игрок Сдох!");
                    enableGame = false;
                }
                else
                {
                    Console.WriteLine(
                        "Статистика Боса: \n Здоровье: {0} , Урон: {1} \n\nСтатистика игрока: \n Здоровье: {2} , Мана: {3} \n",
                        healthBoss, damageBoss, healthPlayer, manaPlayer);
                    Console.WriteLine("Введите заклинание: ");
                    enterSpell = Console.ReadLine();

                    switch (enterSpell)
                    {
                        case "fireball":
                            if (manaPlayer >= 30)
                            {
                                healthBoss -= 50;
                                manaPlayer -= 30;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }

                            break;
                        case "sourcelife":
                            if (manaPlayer >= 50)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (healthPlayer <= 250)
                                    {
                                        healthPlayer += 20;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Ваше текущее здоровье равно: {0}/250", healthPlayer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас полный запас здоровья!");
                                    }
                                }

                                manaPlayer -= 50;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }

                            break;
                        case "lightningstrike":
                            if (manaPlayer >= 45)
                            {
                                healthBoss -= 100;
                                manaPlayer -= 45;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }

                            break;
                        case "toxicsmoke":
                            if (manaPlayer >= 50)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    healthBoss -= 35;
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Урон по босу ядом: {0}", healthBoss);
                                }

                                manaPlayer -= 50;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }

                            break;
                        case "killboss":
                            healthBoss -= healthBoss + 10;
                            break;
                        default:
                            Console.WriteLine("Вы не знаетете {0} это заклинания или вы произнесли его не правильно.",
                                enterSpell);
                            break;
                    }

                    healthPlayer -= damageBoss;
                    healthBoss += 10;
                    manaPlayer += 15;
                }
            }
        }
    }
}