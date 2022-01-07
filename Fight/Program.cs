using System;
using System.Collections.Generic;

namespace Fight
{
    class Program
    {
        private static int _firstFighterId = 5;
        private static int _secondFighterId = 5;
        private static List<Fighter> _fighters = new List<Fighter>()
        {
            new Berserk(100.0, 5.0, 5, 2),
            new Boxer(100.0, 5.0, 5),
            new Vampire(100.0, 5.0, 5, 2),
            new LivingTree(100.0, 5.0, 5, 2),
            new ToxicGoo(100.0, 5.0, 5, 2)
        };
        static void Main(string[] args)
        {
            ChooseFighter(ref _firstFighterId);
            ChooseFighter(ref _secondFighterId);

            while (_fighters[_firstFighterId].IsAlive == true && _fighters[_secondFighterId].IsAlive == true)
            {
                Console.Clear();
                _fighters[_firstFighterId].ShowStat();
                _fighters[_secondFighterId].ShowStat();
                _fighters[_firstFighterId].Attack(_fighters[_secondFighterId]);
                Console.ReadKey();
                _fighters[_secondFighterId].Attack(_fighters[_firstFighterId]);
                Console.ReadKey();
            }
        }
        static void ChooseFighter(ref int fighterId)
        {
            Console.WriteLine("Выберете бойца");
            for (int i = 0; i < _fighters.Count; i++)
            {
                if (i != _firstFighterId)
                {
                    Console.WriteLine(i + ". " + _fighters[i].ShowName());
                }
            }

            switch (Console.ReadLine())
            {
                case "0":
                    fighterId = 0;
                    break;
                case "1":
                    fighterId = 1;
                    break;
                case "2":
                    fighterId = 2;
                    break;
                case "3":
                    fighterId = 3;
                    break;
                case "4":
                    fighterId = 4;
                    break;
                default:
                    Console.WriteLine("Невверный ввод!");
                    break;
            }
        }
    }

    class Fighter
    {
        protected double OneHundredPreCent;
        protected string Name;
        protected double Health;
        protected double Damage;
        protected int Armor;
        protected Random Random;
        public bool IsAlive => Health > 0;

        public Fighter(double health, double damage, int armor)
        {
            OneHundredPreCent = 100.0;
            Random = new Random();
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public virtual void Attack(Fighter fighter)
        {
            fighter.TakeDamage(Damage);
        }
        public void ShowStat()
        {
            Console.WriteLine("Боец " + Name + " HP = " + Health + " DMG = " + Damage + " ARM = " + Armor);
        }

        public string ShowName()
        {
            return Name;
        }
        private void TakeDamage(double damage)
        {
            double blockedDamage = Armor / OneHundredPreCent;
            blockedDamage = damage * blockedDamage;
            Health -= damage - blockedDamage;
            if (IsAlive == false)
            {
                Console.WriteLine(Name + " погибает");
            }
        }
    }

    class Boxer : Fighter
    {
        private int _chanceForDoubleAttack;
        private int _countExtraAtacks;

        public Boxer(double health, double damage, int armor) : base(health, damage, armor)
        {
            Name = "Боксер";
            _chanceForDoubleAttack = 30;
            _countExtraAtacks = 2;
        }

        public override void Attack(Fighter fighter)
        {
            base.Attack(fighter);
            if (Random.Next(0, Convert.ToInt32(OneHundredPreCent)) <= _chanceForDoubleAttack)
            {
                base.Attack(fighter);
                Console.WriteLine("Боксер наносит двойной удар! = " + Damage * _countExtraAtacks + " урона");
            }
            else
            {
                Console.WriteLine("Боксер наносит удар! = " + Damage + " урона");
            }
        }
    }

    class Vampire : Fighter
    {
        private double _lifeRestore;

        public Vampire(double health, double damage, int armor, int lifeRestore) : base(health, damage, armor)
        {
            _lifeRestore = lifeRestore;
            Name = "Вампир";
        }

        public override void Attack(Fighter fighter)
        {
            base.Attack(fighter);
            Health += _lifeRestore;
            Console.WriteLine("Вампир наносит удар! = " + Damage + " и восстанавливает " + _lifeRestore + " здоровья");
        }
    }

    class LivingTree : Fighter
    {
        private int _armorGrow;

        public LivingTree(double health, double damage, int armor, int armorGrow) : base(health, damage, armor)
        {
            _armorGrow = armorGrow;
            Name = "Живое дерево";
        }

        public override void Attack(Fighter fighter)
        {
            base.Attack(fighter);
            Armor += _armorGrow;
            Console.WriteLine(
                "Живое дерево наносит удар! = " + Damage + " и наростает себе " + _armorGrow + " ед брони");
        }
    }

    class Berserk : Fighter
    {
        private int _damageIncreease;

        public Berserk(double health, double damage, int armor, int damageIncreease) : base(health, damage, armor)
        {
            _damageIncreease = damageIncreease;
            Name = "берсерк";
        }

        public override void Attack(Fighter fighter)
        {
            base.Attack(fighter);
            Damage += _damageIncreease;
            Console.WriteLine("Берсерк наносит удар! = " + Damage + ", его урон увеличился на " + _damageIncreease +
                              " ед");
        }
    }

    class ToxicGoo : Fighter
    {
        private int _increesePoint;

        public ToxicGoo(double health, double damage, int armor, int increesePoint) : base(health, damage, armor)
        {
            _increesePoint = increesePoint;
            Name = "Сопли";
        }

        public override void Attack(Fighter fighter)
        {
            base.Attack(fighter);
            switch (Random.Next(1, 3))
            {
                case 1:
                    IncreeaseParametr(1);
                    break;
                case 2:
                    IncreeaseParametr(2);
                    break;
                case 3:
                    IncreeaseParametr(3);
                    break;
            }
        }

        private void IncreeaseParametr(int parametr)
        {
            if (parametr == 1)
            {
                Damage += _increesePoint;
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + " и увеличивает урон на" +
                                  _increesePoint);
            }
            else if (parametr == 2)
            {
                Armor += _increesePoint;
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + " и становится крепче на" +
                                  _increesePoint);
            }
            else
            {
                Health += _increesePoint;
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + " и восстанавливается на" +
                                  _increesePoint);
            }
        }
    }
}