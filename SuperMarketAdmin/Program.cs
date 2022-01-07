using System;
using System.Collections.Generic;

namespace SuperMarketAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Customer
    {
        private Random _random;
        private int _money;
        private int _minMoneyAmount = 100;
        private int _maxMoneyAmount = 1500;
        private Dictionary<string, int> _basket;

        public Customer()
        {
            _random.Next(_minMoneyAmount, _maxMoneyAmount);
            _basket = new Dictionary<string, int>();
        }

        public void FillBasket(int countOfProducts)
        {
            
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public string Name => _name;
        public int Price => _price;

        public Product()
        {
            _name = name;
            _price = price;
        }
        
    }
    class AllProducts
    {
        private Dictionary<string, int> _products = new Dictionary<string, int>();

        public AllProducts()
        {
            _products.Add("Сыр", 250);
            _products.Add("Молоко", 150);
            _products.Add("Хлеб", 50);
            _products.Add("Шоколадка", 75);
            _products.Add("Яйца", 125);
            _products.Add("Колбаса", 300);
            _products.Add("Тесто", 100);
            _products.Add("Газировка", 60);
            _products.Add("Чипсы", 55);
            _products.Add("Рыба", 280);
            _products.Add("Горошек", 70);
            _products.Add("Кукуруза", 70);
        }

        public int ShowCount()
        {
            return _products.Count;
        }

        public string ShowTitle(int id)
        {
            return _products.Comparer
        }
    }
}