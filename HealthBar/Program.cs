using System;

namespace HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentHealth = 100;
            int maxHealth = 100;
            bool isExit = false;
            int basicAttack = 10;
            int heavyAttack = 20;


            while (isExit == false)
            {
                Console.Clear();
                ShowHealth(currentHealth, maxHealth);
                
                Console.WriteLine("Бей! \n" +
                                  "1. Обычная атака \n" +
                                  "2. Тяжелая атака \n" +
                                  "3. Выход \n");

                switch (Console.ReadLine())
                {
                    case "1":
                        BasicAttack(basicAttack,ref currentHealth);
                        break;
                    case "2":
                       HeavyAttack(heavyAttack,ref currentHealth);
                        break;
                    case "3":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }

                if (currentHealth <= 0)
                {
                    Console.WriteLine("Победа!");
                    isExit = true;
                }
            }
           
        }

        public static void ShowHealth(int currentHealth, int maxhealth)
        {
            Console.Write("[");
            for (int i = 0; i < currentHealth; i += 10)
            {
                Console.Write("#");
            }
            for (int i = 0; i < (maxhealth - currentHealth); i += 10)
            {
                Console.Write("-");
            }
            Console.WriteLine("]");
        }

        public static void BasicAttack(int damage,ref int currentHealth)
        {
            currentHealth -= damage;

        }
        
        public static void HeavyAttack(int damage,ref int currentHealth)
        {
            currentHealth -= damage;
        }
    }
}