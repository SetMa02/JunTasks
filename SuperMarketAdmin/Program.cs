using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace SuperMarketAdmin
{
    class Program
    {
        private static Queue<Customer> _customers;
        
        public static  readonly Random Random = new Random();
        static void Main(string[] args)
        {
            
            int minMoney = 100;
            int maxmoney = 1500;
            int customers = 10;
            _customers = new Queue<Customer>();
            for (int i = 0; i < customers; i++)
            {
                _customers.Enqueue(new Customer(Random.Next(minMoney, maxmoney)));
            }

            while (_customers.Any() == true)
            {
                Customer customer = _customers.Dequeue();
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
                Console.ReadKey();
                _customers.Dequeue();
                Console.Clear();
            }
            Console.WriteLine("Посетитили кончились");
           
        }

        private static bool CheckEnoughMoney(Customer customer)
        {
            bool isEnough = false;
            int totalProductCost = 0;
            for (int i = 0; i < customer.ShowCount(); i++)
            {
                totalProductCost += customer.GetProduct(i).Price;
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
        private int _money;
        private int _minMoneyAmount;
        private int _maxMoneyAmount;
        private List<Product> _basket;
        private AllProducts _allProducts;

        public int Money => _money;

        public Customer(int money)
        {
            _money = money;
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
            int removeindex = Program.Random.Next(0, _basket.Count);
            Console.WriteLine(_basket[removeindex].Name + " убран");
            _basket.RemoveAt(removeindex);
        }

        public int ShowCount()
        {
            return _basket.Count;
        }

        public Product GetProduct(int id)
        {
            return _basket[id];
        }

        private void FillBasket()
        {
            _allProducts = new AllProducts();
            int productsCount = Program.Random.Next(1, _allProducts.ShowCount());
            for (int i = 0; i < productsCount; i++)
            {
                _basket.Add(_allProducts.ShowProduct(Program.Random.Next(0, _allProducts.ShowCount())));
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
            _allProducts = new List<Product>();
            _allProducts.Add(new Product("Молоко", 80));
            _allProducts.Add(new Product("Яйца", 100));
            _allProducts.Add(new Product("Колбаса", 200));
            _allProducts.Add(new Product("Баранки", 75));
            _allProducts.Add(new Product("Хлеб", 30));
            _allProducts.Add(new Product("Мороженое", 50));
            _allProducts.Add(new Product("Тесто", 80));
            _allProducts.Add(new Product("Сыр", 90));
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