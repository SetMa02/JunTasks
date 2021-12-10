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
            int step = 10;
            int basicAttack = 10;
            int heavyAttack = 20;
            
            while (isExit == false)
            {
                Console.Clear();
                DrawBar(currentHealth, maxHealth, step);
                
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

        public static void DrawBar(int currentHealth, int maxhealth, int step)
        {
            Console.Write("[");

            for (int i = 0; i < maxhealth; i += maxhealth/step)
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