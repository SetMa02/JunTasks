using System;
using System.Collections.Generic;

namespace aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            int aquariumCapacity;
            int maxFishLives;
            Console.WriteLine("Склолько рыб вмещает аквариум: ");
            aquariumCapacity = AskInput();
            Console.WriteLine("Сколько всего живет рыба:");
            maxFishLives = AskInput();
            Aquarium aquarium = new Aquarium(aquariumCapacity, maxFishLives);
            bool isExit = false;

            while (isExit == false)
            {
                aquarium.ShowAllFish();
                Console.WriteLine("Что делать? \n" +
                                  "1. Добавить рыбку \n" +
                                  "2. убрать рыбку\n" +
                                  "3. ничего \n" +
                                  "4. выйти");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        aquarium.AddFish();
                        break;
                    case "2":
                        RemoveFish(aquarium);
                        break;
                    case "3":
                        Console.WriteLine("рыбки плавуют");
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Невенрый ввод");
                        break;
                }
                Console.Clear();
            }
        }
        private static void RemoveFish(Aquarium aquarium)
        {
            int deleteIndex = 0;
            Console.WriteLine("какую убрать?");
            deleteIndex = AskInput();
            if (deleteIndex <= aquarium.GetCount())
            {
                aquarium.RemoveFish(deleteIndex);
            }
            else
            {
                Console.WriteLine("Неверный индекс!");
            }
        }
        
        private static int AskInput()
        {
            bool isCorrect = false;
            int result = 0;
            while (isCorrect == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out result) == false)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                else
                {
                    isCorrect = true;
                }
            }

            return result;
        }
    }

    class Aquarium
    {
        private Random _random;
        private List<Fish> _fishes;
        private int _fishCapacity;
        private int _maxFishLife ;

        public int FishCapacity => _fishCapacity;
        public Aquarium(int fishCapacity, int maxFishLife)
        {
            _fishes = new List<Fish>();
            _random = new Random();
            _fishCapacity = fishCapacity;
            _maxFishLife = maxFishLife;
        }

        public void ShowAllFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                _fishes[i].ShowStat(i);
                Console.WriteLine();
                _fishes[i].LiveDecreease();
            }
        }

        public int GetCount()
        {
            return _fishes.Count;
        }
        public void AddFish()
        {
            if (_fishes.Count >= _fishCapacity-1)
            {
                Console.WriteLine("Аквариум заполнен!");
            }
            else
            {
                _fishes.Add(new Fish(_random.Next(0, _maxFishLife)));
                Console.WriteLine("Рыбка добавлена");
            }
            Console.WriteLine();
        }

        public void RemoveFish(int index)
        {
            _fishes.RemoveAt(index);
            Console.WriteLine("Рыбка убрана");
        }
    }

    class Fish
    {
        private int _lifeTime;

        public bool IsAlive => _lifeTime > 0;
        public Fish(int lifeTime)
        {
            _lifeTime = lifeTime;
        }

        public void LiveDecreease()
        {
            _lifeTime--;
        }
        
        public void ShowStat(int index)
        {
            if (IsAlive == true)
            {
                Console.Write(index + ". Рыбка - " + _lifeTime);
            }
            else
            {
                Console.Write(index + ". Рыбка умерла(");
            }
        }
    }
}