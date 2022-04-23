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
            ConflictSide firstConflictSide;
            ConflictSide secondConflictSide;
            CreatePlatoons(out firstConflictSide, out secondConflictSide);
            StartWar(firstConflictSide, secondConflictSide);
            CheckWinner(firstConflictSide, secondConflictSide);
        }

        public static void CheckWinner(ConflictSide firstConflictSide, ConflictSide secondConflictSide)
        {
            if (firstConflictSide.IsAlive == true)
            {
                Console.WriteLine("Ура победил " + firstConflictSide.Name);
            }
            else if (secondConflictSide.IsAlive == true)
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

        private static void StartWar(ConflictSide firstConflictSide, ConflictSide secondConflictSide)
        {
            War war = new War(firstConflictSide, secondConflictSide);
            war.StartWar();
        }

        private static void CreatePlatoons(out ConflictSide firstConflictSide, out ConflictSide secondConflictSide)
        {
            string sideName;
            int sideTroopersCount;
            int maxTrooperhealth = 250;
            int maxTrooperDamage = 250;

            Console.WriteLine("Введите название первого взвода:");
            sideName = Console.ReadLine();
            Console.WriteLine("Введите количество солдат первого взвода:");
            sideTroopersCount = AskInput();
            firstConflictSide = new ConflictSide(sideName, maxTrooperhealth, maxTrooperDamage);
            firstConflictSide.CreateTroopers(sideTroopersCount);
            Console.WriteLine("Введите название второго взвода:");
            sideName = Console.ReadLine();
            Console.WriteLine("Введите количество солдат второго взвода:");
            sideTroopersCount = AskInput();
            secondConflictSide = new ConflictSide(sideName, maxTrooperhealth, maxTrooperDamage);
            secondConflictSide.CreateTroopers(sideTroopersCount);
        }
    }

    class ConflictSide
    {
        private string _name;
        private List<Trooper> _troopers;
        private int _maxTropperHealth;
        private int _maxTropperDamage;

        public string Name => _name;
        public bool IsAlive => _troopers.Count > 0;
        public int ShowArmyCount => _troopers.Count;


        public ConflictSide(string name, int maxTropperHealth, int maxTropperDamage)
        {
            _troopers = new List<Trooper>();
            _maxTropperHealth = maxTropperHealth;
            _maxTropperDamage = maxTropperDamage;
            _name = name;
        }

        public Trooper GetTrooper(int index)
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

        public void CreateTroopers(int troopersCount)
        {
            for (int i = 1; i < troopersCount; i++)
            {
                _troopers.Add(new Trooper(Program.Random.Next(1, _maxTropperHealth),
                    Program.Random.Next(0, _maxTropperDamage)));
            }
        }
    }

    class War
    {
        private ConflictSide _firstConflictSide;
        private ConflictSide _secondConflictSide;

        public War(ConflictSide firstConflictSide, ConflictSide secondConflictSide)
        {
            _firstConflictSide = firstConflictSide;
            _secondConflictSide = secondConflictSide;
        }

        public void StartWar()
        {
            while (_firstConflictSide.IsAlive == true && _secondConflictSide.IsAlive == true)
            {
                if (_firstConflictSide.IsAlive == true && _secondConflictSide.IsAlive == true)
                {
                    Attack(_firstConflictSide, _secondConflictSide);
                    _secondConflictSide.RemoveDeadTroopers();
                }

                if (_secondConflictSide.IsAlive == true && _firstConflictSide.IsAlive == true)
                {
                    Attack(_secondConflictSide, _firstConflictSide);
                    _firstConflictSide.RemoveDeadTroopers();
                }
            }
        }

        private void Attack(ConflictSide Attacking, ConflictSide Attacked)
        {
            Console.WriteLine(Attacking.Name + " войска = " + Attacked.ShowArmyCount);
            int attackTropperId = Program.Random.Next(0, Attacking.ShowArmyCount);
            int conflictTrooperId = Program.Random.Next(0, Attacked.ShowArmyCount);
            Console.WriteLine(Attacking.Name + " атаковала " + Attacked.Name + " уроном равный " +
                              Attacking.GetTrooper(attackTropperId).Damage);
            Attacking.GetTrooper(attackTropperId).Attack(Attacked.GetTrooper(conflictTrooperId));
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