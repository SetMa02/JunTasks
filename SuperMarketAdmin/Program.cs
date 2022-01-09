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
        static void Main(string[] args)
        {
            int minMoney = 100;
            int maxmoney = 1500;
            int customers = 10;
            SuperMarket superMarket = new SuperMarket(customers, minMoney, maxmoney);

            while (superMarket.isThereCustomers() == true)
            {
                Customer customer = superMarket.GetCustomer();
                Console.WriteLine("К вам подходит покупатель");
                customer.ShowBasket();
                Console.WriteLine("У покупателя " + customer.Money + " денег");
                while (CheckEnoughMoney(customer) == false)
                {
                    Console.WriteLine("У покупателя недостаточно средств... \n" +
                                      "Убираем лишний товар");
                    customer.RemoveRandomProduct();
                }

                customer.SubtrackMoney(customer.SummAllProducts());
                Console.WriteLine("Денег хватает \n" +
                                  "Следуйщий покупатель!");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Посетитили кончились");
        }

        private static bool CheckEnoughMoney(Customer customer)
        {
            bool isEnough = false;

            if (customer.Money >= customer.SummAllProducts())
            {
                Console.WriteLine("Покупок на сумму " + customer.SummAllProducts());
                isEnough = true;
            }

            return isEnough;
        }
    }

    class SuperMarket
    {
        private Storge _allProducts;
        private Queue<Customer> _customers;

        public static readonly Random Random = new Random();

        public SuperMarket(int customersCount, int minMoney, int maxmoney)
        {
            _customers = new Queue<Customer>();
            for (int i = 0; i < customersCount; i++)
            {
                _customers.Enqueue(new Customer(Random.Next(minMoney, maxmoney)));
            }
        }

        public Customer GetCustomer()
        {
            return _customers.Dequeue();
        }

        public bool isThereCustomers()
        {
            return _customers.Any();
        }
    }

    class Customer
    {
        private int _money;
        private int _minMoneyAmount;
        private int _maxMoneyAmount;
        private List<Product> _basket;
        private Storge _storge;

        public int Money => _money;

        public Customer(int money)
        {
            _money = money;
            _basket = new List<Product>() { };
            FillBasket();
        }

        public void SubtrackMoney(int moneyAmount)
        {
            _money -= moneyAmount;
        }

        public void ShowBasket()
        {
            Console.WriteLine("Корзина покупателя:");
            for (int i = 0; i < _basket.Count; i++)
            {
                Console.WriteLine(i + ". " + _basket[i].Name + " - " + _basket[i].Price);
            }
        }

        public int SummAllProducts()
        {
            int totalProductCost = 0;
            foreach (var product in _basket)
            {
                totalProductCost += product.Price;
            }

            return totalProductCost;
        }


        public void RemoveRandomProduct()
        {
            int removeindex = SuperMarket.Random.Next(0, _basket.Count);
            Console.WriteLine(_basket[removeindex].Name + " убран");
            _basket.RemoveAt(removeindex);
        }

        public int GetCount()
        {
            return _basket.Count;
        }

        public Product GetProduct(int id)
        {
            return _basket[id];
        }

        private void FillBasket()
        {
            _storge = new Storge();
            int productsCount = SuperMarket.Random.Next(1, _storge.ShowCount());
            for (int i = 0; i < productsCount; i++)
            {
                _basket.Add(_storge.ShowProduct(SuperMarket.Random.Next(0, _storge.ShowCount())));
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

    class Storge
    {
        private List<Product> _allProducts;

        public Storge()
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