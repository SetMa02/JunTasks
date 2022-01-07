using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Xml;

namespace SuperMarketAdmin
{
    class Program
    {
        private static List<Customer> _customers;

        static void Main(string[] args)
        {
            int customers = 10;
            _customers = new List<Customer>() { };
            for (int i = 0; i < customers; i++)
            {
                _customers.Add(new Customer());
            }

            foreach (var customer in _customers)
            {
                Console.WriteLine("К вам подходит покупатель");
                customer.ShowBasket();
                Console.WriteLine("У покупателя " + customer.Money + " денег");
                while (CheckEnoughMoney(customer) == false)
                {
                    Console.WriteLine("У покупателя недостаточно средств... \n" +
                                      "Убираем лишний товар");
                    customer.RemoveRandomProduct();
                }

                Console.WriteLine("Денег хватает \n" +
                                  "Следуйщий покупатель!");
                _customers.Remove(customer);
            }

            Console.WriteLine("Посетитили кончились");
        }

        private static bool CheckEnoughMoney(Customer customer)
        {
            bool isEnough = false;
            int totalProductCost = 0;
            for (int i = 0; i < customer.ShowCount(); i++)
            {
                totalProductCost += customer.ShowProduct(i).Price;
            }

            Console.WriteLine("Покупок вышло на сумму = " + totalProductCost);
            if (customer.Money >= totalProductCost)
            {
                isEnough = true;
            }

            return isEnough;
        }
    }

    class Customer
    {
        private Random _random;
        private int _money;
        private int _minMoneyAmount;
        private int _maxMoneyAmount;
        private List<Product> _basket;
        private AllProducts _allProducts;

        public int Money => _money;

        public Customer()
        {
            _random = new Random();
            _minMoneyAmount = 100;
            _maxMoneyAmount = 1500;
            _money = _random.Next(_minMoneyAmount, _maxMoneyAmount);
            _allProducts = new AllProducts();
            _basket = new List<Product>() { };
            FillBasket();
        }

        public void ShowBasket()
        {
            Console.WriteLine("Корзина покупателя:");
            for (int i = 0; i < _basket.Count; i++)
            {
                Console.WriteLine(i + ". " + _basket[i].Name + " - " + _basket[i].Price);
            }
        }

        public void RemoveRandomProduct()
        {
            int removeindex = _random.Next(0, _basket.Count);
            Console.WriteLine(_basket[removeindex].Name + " убран");
            _basket.RemoveAt(removeindex);
        }

        public int ShowCount()
        {
            return _basket.Count;
        }

        public Product ShowProduct(int id)
        {
            return _basket[id];
        }

        private void FillBasket()
        {
            int productsCount = _random.Next(1, _allProducts.ShowCount());
            for (int i = 0; i < productsCount; i++)
            {
                _basket[i] = _allProducts.ShowProduct(_random.Next(0, _allProducts.ShowCount()));
            }
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public string Name => _name;
        public int Price => _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }

    class AllProducts
    {
        private List<Product> _allProducts;

        public AllProducts()
        {
            _allProducts = new List<Product>()
            {
                new Product("Молоко", 80),
                new Product("Яйца", 100),
                new Product("Колбаса", 200),
                new Product("Баранки", 75),
                new Product("Хлеб", 30),
                new Product("Мороженое", 50),
                new Product("Тесто", 80),
                new Product("Сыр", 90)
            };
        }

        public int ShowCount()
        {
            return _allProducts.Count;
        }

        public Product ShowProduct(int id)
        {
            return _allProducts[id];
        }
    }
}