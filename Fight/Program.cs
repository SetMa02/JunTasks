using System;

namespace Fight
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    class Fighter
    {
        protected double Health;
        protected double Damage;
        protected int Armor;

        public Fighter(double health, double damage, int armor)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }
        
        public virtual void Attack(Fighter fighter1, Fighter fighter2)
        {
            double blockedDamage = fighter2.Armor / 100.0;
            blockedDamage = fighter1.Damage * blockedDamage;
            fighter2.Health -= fighter1.Damage - blockedDamage;
        }
    }

    class Boxer : Fighter
    {
        private Random _random;
        private int _chanceForDoubleAttack;

        public Boxer(double health, double damage, int armor) : base(health, damage, armor)
        {
            _random = new Random();
            _chanceForDoubleAttack = 3;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
            if (_random.Next(1,10) <= _chanceForDoubleAttack)
            {
                base.Attack(fighter1, fighter2);
            }
        }
    }

    class Vampire : Fighter
    {
        private double _lifeRestore;

        public Vampire(double health, double damage, int armor, int lifeRestore) : base(health, damage, armor)
        {
            _lifeRestore = lifeRestore;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
            Health += _lifeRestore;
        }
    }

    class LivingTree : Fighter
    {
        private int _armorGrow;

        public LivingTree(double health, double damage, int armor, int armorGrow) : base(health, damage, armor)
        {
            _armorGrow = armorGrow;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
            Armor += _armorGrow;
        }
    }

    class Berserk : Fighter
    {
        private int _damageIncreease;

        public Berserk(double health, double damage, int armor, int damageIncreease) : base(health, damage, armor)
        {
            _damageIncreease = damageIncreease;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
            Damage += _damageIncreease;
        }
    }

    class ToxicMess : Fighter
    {
        private int _armorDecreease;

        public ToxicMess(double health, double damage, int armor, int armorDecreease) : base(health, damage, armor)
        {
            _armorDecreease = armorDecreease;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
            
        }
    }
}