using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int healthBoss = 1000;
            int bossMinDamage = 30;
            int bossMaxDamage = 100;

            int healthPlayer = 500;
            int manaPlayer = 200;
            bool enableGame = true;
            int currentCritRate = 5;
            int minCritRate = 5;
            int critMultiplier = 2;

            bool isStunned = false;
            int sunlightManaCost = 30;

            bool isMeditate = false;
            int meditatiaHpRecover = 100;
            int meditationManaRecover = 50;
            int meditationDebuff = 1;

            int lightningstrikeDamage = 100;
            int lightningstrikeManaCost = 45;

            bool isPoisened = false;
            int smokeLong = 5;
            int smokeMaxLong = 5;
            int smokeDamage = 20;
            int smokeManaCost = 60;
            int smokeTotalDamage = 0;

            int totalMeditationCritRateBuff = 15;
            int hiddenBladeDamageBuff = 50;
            int buffDamage = 0;


            int minCritChance = 0;
            int maxCritChance = 100;
            int buffMiltiplier = 2;
            
            Console.WriteLine(
                $"Передвами стоит огромный ДедИнсайд он настроен агресивно избежать драки не возможно приготовтесь к битве. \n Ваши доступные заклинания: \n" +
                $"1) sunlight - Ослеплеющий свет, станит противника на 2 хода, отнимает {sunlightManaCost} едениц маны.\n" +
                $"2) meditation - Востанавливает игроку {meditatiaHpRecover} ХП и {meditationManaRecover} единиц маны, игрок не может применять атакующие спелы {meditationDebuff} ход\n" +
                $"3) lightningstrike - Удар молнией наносит {lightningstrikeDamage} урона, пробуждает ослепленного врага, отнимает {lightningstrikeManaCost} едениц маны.\n" +
                $"4) toxicsmoke - Создается ядовитое облако и наносит {smokeDamage} урона или, если враг ослеплен {smokeDamage * 2}, в течении {smokeLong} ходов, отнимает {smokeManaCost} единиц маны.\n");

            Console.WriteLine("Во время медитации вы можете использовать следуйщие заклинания: \n" +
                              $"1) Total Meditation - продолжаете медитировать еще 1 ход и восстанавливаете {meditatiaHpRecover * 2} и {meditationManaRecover * 2} так же увеличивает шанс крита на {totalMeditationCritRateBuff}%\n" +
                              $"2) Hidden Blade - приготавливаетесь к следуйщей атаке, нанося {hiddenBladeDamageBuff} дополнительного урона\n" +
                              $"3) Wake up - Выход из медитации");

            while (enableGame == true)
            {
                Console.WriteLine($"ДедИнстай - {healthBoss}hp");
                Console.WriteLine($"Ваше HP - {healthPlayer}, MP {manaPlayer}");

                if (isMeditate == false)
                {
                    Console.WriteLine("Введите заклинание:");
                    Console.WriteLine(
                        $"1) sunlight\n" +
                        $"2) meditation\n" +
                        $"3) lightningstrike\n" +
                        $"4) toxicsmoke");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Враг ослеплен!");
                            isStunned = true;
                            manaPlayer -= sunlightManaCost;
                            break;
                        case "2":
                            Console.WriteLine("Медитация!");
                            isMeditate = true;
                            healthPlayer = meditatiaHpRecover;
                            healthPlayer = meditationManaRecover;
                            break;
                        case "3":
                            Console.WriteLine("Удар молнии!");
                            if (random.Next(minCritChance, maxCritChance) <= currentCritRate)
                            {
                                Console.WriteLine("Кританул!");
                                healthBoss -= lightningstrikeDamage * critMultiplier + buffDamage;
                            }
                            else
                            {
                                healthBoss -= lightningstrikeDamage + buffDamage;
                            }

                            isStunned = false;
                            break;
                        case "4":
                            Console.WriteLine("Отравленный туман!");
                            if (isStunned = true)
                            {
                                smokeTotalDamage = smokeDamage * buffMiltiplier;
                            }

                            isPoisened = true;
                            smokeTotalDamage = smokeDamage;
                            break;
                        default:
                            Console.WriteLine("Вы не правильно прочитали заклинане, ход пропущен");
                            break;
                    }
                }

                buffDamage = 0;
                currentCritRate = minCritRate;

                if (isPoisened == true)
                {
                    Console.WriteLine("Босс травится!");
                    smokeLong--;
                    healthBoss -= smokeTotalDamage;
                }

                if (smokeLong == 0)
                {
                    Console.WriteLine("Босс больше не отравлен!");
                    isPoisened = false;
                    smokeLong = smokeMaxLong;
                }

                if (isMeditate == true)
                {
                    isMeditate = false;
                    Console.WriteLine("Введите заклинание:");
                    Console.WriteLine(
                        $"1) Total Meditation\n" +
                        $"2) Hidden Blade\n" +
                        $"3) Wake up");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            healthPlayer += meditatiaHpRecover * buffMiltiplier;
                            manaPlayer += meditationManaRecover * buffMiltiplier;
                            currentCritRate = totalMeditationCritRateBuff;
                            isMeditate = true;
                            break;
                        case "2":
                            buffDamage = hiddenBladeDamageBuff;
                            break;
                        case "3":
                            isMeditate = false;
                            break;
                        default:
                            Console.WriteLine("Вы не правильно прочитали заклинане, ход пропущен");
                            break;
                    }
                }

                if (isStunned == false)
                {
                    Console.WriteLine("Вас Атакуют!");
                    healthPlayer -= random.Next(bossMinDamage, bossMaxDamage);
                }

                if (healthBoss <= 0)
                {
                    enableGame = false;
                    Console.WriteLine("Победа!!!");
                }

                if (healthPlayer <= 0)
                {
                    enableGame = false;
                    Console.WriteLine("Поражение(");
                }

                isStunned = false;
            }
        }
    }
}