﻿using System;
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

            while (firstConflictSide.IsWin == false || secondConflictSide.IsWin == false)
            {
                firstConflictSide.War(secondConflictSide);
                secondConflictSide.RemoveDeadTroopers();
                secondConflictSide.War(firstConflictSide);
                firstConflictSide.RemoveDeadTroopers();
            }
            CheckWinner(firstConflictSide);
            CheckWinner(secondConflictSide);
        }

        private static void CheckWinner(ConflictSide conflictSide)
        {
            if (conflictSide.IsWin == true)
            {
                 Console.WriteLine("Ура победил " + conflictSide.Name);
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

        public bool IsWin => !_troopers.Any(); 

        public string Name => _name;

        public ConflictSide(int troopersCount, string name)
        {
            _troopers = new List<Trooper>();
            _maxTropperHealth = 250;
            _maxTropperDamage = 250;
            _name = name;
            for (int i = 1; i < troopersCount; i++)
            {
                _troopers.Add(new Trooper(Program.Random.Next(1, _maxTropperHealth), Program.Random.Next(0, _maxTropperDamage)));
            }
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
                while (!deadTroppers.Any())
                {
                    _troopers.RemoveAt(deadTroppers.Dequeue());
                }
                Console.WriteLine("убрано " + countDead);
                _troopers.RemoveAt(deadTroppers.Dequeue());
            }
        }
        
        public void War(ConflictSide conflictSide)
        {
            Console.WriteLine(_name + " войска = " + _troopers.Count);
            int attackTropperId;
            int conflictTrooperId;
            attackTropperId = Program.Random.Next(0, _troopers.Count);
            do
            {
                conflictTrooperId = Program.Random.Next(0, conflictSide.ShowArmyCount());
            } while (ShowTrooper(conflictTrooperId).IsAlive == false);
            
            Console.WriteLine(_name +" атаковала " + conflictSide.Name + " уроном равный " + _troopers[attackTropperId].Damage);
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
