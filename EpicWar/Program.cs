using System;
using System.Collections.Generic;
using System.Linq;

namespace EpicWar
{
    class Program
    {
        public static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            string sideName;
            int sideTroopersCount;
            Console.WriteLine("Введите название первого взвода:");
            sideName = Console.ReadLine();
            Console.WriteLine("Введите количество содлат первого взвода:");
            sideTroopersCount = AskInput();
            ConflictSide firstConflictSide = new ConflictSide(sideTroopersCount, sideName);

            Console.WriteLine("Введите название второго взвода:");
            sideName = Console.ReadLine();
            Console.WriteLine("Введите количество содлат второго взвода:");
            sideTroopersCount = AskInput();
            ConflictSide secondConflictSide = new ConflictSide(sideTroopersCount, sideName);

            while (firstConflictSide.CheckAlive() != false && secondConflictSide.CheckAlive() != false)
            {
                if (firstConflictSide.CheckAlive() && secondConflictSide.CheckAlive())
                {
                    firstConflictSide.War(secondConflictSide);
                    secondConflictSide.RemoveDeadTroopers();
                }

                if (secondConflictSide.CheckAlive() && firstConflictSide.CheckAlive())
                {
                    secondConflictSide.War(firstConflictSide);
                    firstConflictSide.RemoveDeadTroopers();
                }
            }

                CheckWinner(firstConflictSide,secondConflictSide);
        }

        private static void CheckWinner(ConflictSide firstConflictSide, ConflictSide secondConflictSide)
        {
            if (firstConflictSide.CheckAlive() == true)
            {
                Console.WriteLine("Ура победил " + firstConflictSide.Name);
            }
            else if (secondConflictSide.CheckAlive() == true)
            {
                Console.WriteLine("Ура победил " + secondConflictSide.Name);
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

    class ConflictSide
    {
        private string _name;
        private List<Trooper> _troopers;
        private int _maxTropperHealth;
        private int _maxTropperDamage;

        public string Name => _name;

        public ConflictSide(int troopersCount, string name)
        {
            _troopers = new List<Trooper>();
            _maxTropperHealth = 250;
            _maxTropperDamage = 250;
            _name = name;
            for (int i = 1; i < troopersCount; i++)
            {
                _troopers.Add(new Trooper(Program.Random.Next(1, _maxTropperHealth),
                    Program.Random.Next(0, _maxTropperDamage)));
            }
        }

        public bool CheckAlive()
        {
            return _troopers.Any();
        }

        public int ShowArmyCount()
        {
            return _troopers.Count;
        }

        public Trooper ShowTrooper(int index)
        {
            return _troopers[index];
        }

        public void RemoveDeadTroopers()
        {
            Queue<int> deadTroppers = new Queue<int>();
            for (int i = 0; i < _troopers.Count; i++)
            {
                if (_troopers[i].IsAlive == false)
                {
                    deadTroppers.Enqueue(i);
                }
            }

            int countDead = deadTroppers.Count;
            if (deadTroppers.Any() == true)
            {
                if (_troopers.Any())
                {
                    _troopers.RemoveAt(deadTroppers.Dequeue());
                    Console.WriteLine("убрано " + countDead);
                }
            }
        }

        public void War(ConflictSide conflictSide)
        {
            Console.WriteLine(_name + " войска = " + _troopers.Count);
            int attackTropperId = Program.Random.Next(0, _troopers.Count);
            int conflictTrooperId = Program.Random.Next(0, conflictSide.ShowArmyCount());
            Console.WriteLine(_name + " атаковала " + conflictSide.Name + " уроном равный " +
                              _troopers[attackTropperId].Damage);
            _troopers[attackTropperId].Attack(conflictSide.ShowTrooper(conflictTrooperId));
        }
    }

    class Trooper
    {
        private int _health;
        private int _damage;
        public int Health => _health;
        public int Damage => _damage;
        public bool IsAlive => Health > 0;

        public Trooper(int health, int damage)
        {
            _health = health;
            _damage = damage;
        }

        public void Attack(Trooper trooper)
        {
            trooper.GetDamage(_damage);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
        }
    }
}