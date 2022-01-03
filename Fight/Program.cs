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
        private bool _isDoubleAttack;

        public Boxer(double health, double damage, int armor) : base(health, damage, armor)
        {
            _random = new Random();
            _isDoubleAttack = false;
        }

        public override void Attack(Fighter fighter1, Fighter fighter2)
        {
            base.Attack(fighter1, fighter2);
        }
    }

    class Vampire : Fighter
    {
        private double _lifeRestore;

        public Vampire(double health, double damage, int armor, int lifeRestore) : base(health, damage, armor)
        {
            _lifeRestore = lifeRestore;
        }
        
        
    }
}