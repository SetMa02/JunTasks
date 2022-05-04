using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmergincyFood
{
    class Program
    {
        static void Main(string[] args)
        {
            Storge storge = new Storge();
            
            storge.CleanExpired();
            
            storge.ShowStorage();

        }
    }

    class Storge
    {
        private List<Food> _foods;

        public Storge()
        {
            _foods = new List<Food>()
            {
                new Food("Говядина", 2010, 3),
                new Food("Свинина", 2015, 3),
                new Food("Баранина", 2020, 3),
                new Food("Козлятина", 2021, 3),
                new Food("Паштет", 2005, 3),
                new Food("Шпик", 2019, 3),
                new Food("Плов", 2018, 3),
                new Food("Каша гречневая", 2017, 3),
                new Food("Каша рисовая", 2022, 3),
                new Food("Тушенка", 2015, 3),
                new Food("Говядина", 2021, 3),
            };
            ShowStorage();
            
            Console.WriteLine("");
        }

        public void CleanExpired()
        {
            int currentYear = DateTime.Today.Year;

            _foods = _foods.Where(food => food.ShelfLife + food.Year >=  currentYear).ToList();
        }

        public void ShowStorage()
        {
            foreach (var food in _foods)
            {
                Console.WriteLine($"{_foods.IndexOf(food)}. {food.Name}, {food.Year}");
            }
        }
    }

    class Food
    {
        private string _name;
        private int _year;
        private int _shelfLife;

        public string Name => _name;
        public int Year => _year;
        public int ShelfLife => _shelfLife;

        public Food(string name,int year, int shelfLife )
        {
            _name = name;
            _year = year;
            _shelfLife = shelfLife;
        }
    }
}