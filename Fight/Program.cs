using System;
using System.Collections.Generic;

namespace Fight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;

            int firstFighterId = 5;
            int secondFighterId = 5;

            List<Fighter> fighters = new List<Fighter>()
            {
                new Berserk(100.0, 5.0, 5, 2),
                new Boxer(100.0, 5.0, 5),
                new Vampire(100.0, 5.0, 5, 2),
                new LivingTree(100.0, 5.0, 5, 2),
                new ToxicGoo(100.0, 5.0, 5, 2)
            };

            ChooseFighter(ref firstFighterId);
            ChooseFighter(ref secondFighterId);

            while (isExit == false)
            {
                Console.Clear();
                fighters[firstFighterId].ShowStat();
                fighters[secondFighterId].ShowStat();
                fighters[firstFighterId].Attack(fighters[secondFighterId], ref isExit);
                Console.ReadKey();
                fighters[secondFighterId].Attack(fighters[firstFighterId], ref isExit);
                Console.ReadKey();
            }

            void ChooseFighter(ref int fighterId)
            {
                Console.WriteLine("Выберете бойца");
                for (int i = 0; i < fighters.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + fighters[i].ShowName());
                }

                switch (Console.ReadLine())
                {
                    case "1":
                        fighterId = 0;
                        break;
                    case "2":
                        fighterId = 1;
                        break;
                    case "3":
                        fighterId = 2;
                        break;
                    case "4":
                        fighterId = 3;
                        break;
                    case "5":
                        fighterId = 4;
                        break;
                    default:
                        Console.WriteLine("Невверный ввод!");
                        break;
                }
            }
        }
    }

    class Fighter
    {
        protected string Name;
        protected double Health;
        protected double Damage;
        protected int Armor;

        public Fighter(double health, double damage, int armor)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public virtual void Attack(Fighter fighter, ref bool isExit)
        {
            double blockedDamage = fighter.Armor / 100.0;
            blockedDamage = Damage * blockedDamage;
            fighter.Health -= Damage - blockedDamage;
            if (fighter.Health <= 0)
            {
                Console.WriteLine(fighter.Name + " Погибает");
                isExit = true;
            }
        }

        public void ShowStat()
        {
            Console.WriteLine("Боец " + Name + " HP = " + Health + " DMG = " + Damage + " ARM = " + Armor);
        }

        public string ShowName()
        {
            return Name;
        }
    }

    class Boxer : Fighter
    {
        private Random _random;
        private int _chanceForDoubleAttack;
        private int _countExtraAtacks;

        public Boxer(double health, double damage, int armor) : base(health, damage, armor)
        {
            Name = "Боксер";
            _random = new Random();
            _chanceForDoubleAttack = 3;
            _countExtraAtacks = 2;
        }

        public override void Attack(Fighter fighter, ref bool isExit)
        {
            base.Attack(fighter, ref isExit);
            if (_random.Next(1, 10) <= _chanceForDoubleAttack)
            {
                base.Attack(fighter, ref isExit);
                Console.WriteLine("Боксер наносит двойной удар! = " + Damage * _countExtraAtacks + " урона");
            }
            else
            {
                Console.WriteLine("Боксер наносит двойной удар! = " + Damage + " урона");
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

        public override void Attack(Fighter fighter, ref bool isExit)
        {
            base.Attack(fighter, ref isExit);
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

        public override void Attack(Fighter fighter, ref bool isExit)
        {
            base.Attack(fighter, ref isExit);
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

        public override void Attack(Fighter fighter, ref bool isExit)
        {
            base.Attack(fighter, ref isExit);
            Damage += _damageIncreease;
            Console.WriteLine("Берсерк наносит удар! = " + Damage + ", его урон увеличился на " + _damageIncreease +
                              " ед");
        }
    }

    class ToxicGoo : Fighter
    {
        private int _increesePoint;
        private Random _random;

        public ToxicGoo(double health, double damage, int armor, int increesePoint) : base(health, damage, armor)
        {
            _increesePoint = increesePoint;
            _random = new Random();
            Name = "Сопли";
        }

        public override void Attack(Fighter fighter, ref bool isExit)
        {
            base.Attack(fighter, ref isExit);
            switch (_random.Next(1, 3))
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
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + "и увеличивает урон на" +
                                  _increesePoint);
            }
            else if (parametr == 2)
            {
                Armor += _increesePoint;
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + "и становится крепче на" +
                                  _increesePoint);
            }
            else
            {
                Health += _increesePoint;
                Console.WriteLine("Сопли наносит удар! = " + Damage + " урона" + "и восстанавливается на" +
                                  _increesePoint);
            }
        }
    }
}