using System;

namespace HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentHealth = 1000;
            int maxHealth = 1000;
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
                       Attack(basicAttack,ref currentHealth);
                        break;
                    case "2":
                      Attack(heavyAttack,ref currentHealth);
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

            for (int i = 0; i < maxhealth; i += maxhealth/10)
            {
                if (currentHealth >= i)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write("-");
                }
            }
          
            Console.WriteLine("]");
        }

        public static void Attack(int damage,ref int currentHealth)
        {
            currentHealth -= damage;
        }
        
    }
}