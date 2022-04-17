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
            int maxmoney = 1500;
            int customers = 10;

            SuperMarket superMarket = new SuperMarket(customers, maxmoney);

            while (superMarket.HaveCustomers == true)
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

                customer.SubtrackMoney(customer.SumAllProducts());
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

            if (customer.Money >= customer.SumAllProducts())
            {
                Console.WriteLine("Покупок на сумму " + customer.SumAllProducts());
                isEnough = true;
            }

            return isEnough;
        }
    }

    class SuperMarket
    {
        public static readonly Random Random = new Random();
        public bool HaveCustomers => _customers.Count > 0;

        private Storge _allProducts;
        private Queue<Customer> _customers;

        public SuperMarket(int customersCount, int maxMoney)
        {
            _allProducts = new Storge();
            _customers = new Queue<Customer>();
            int customerProductsCount = Random.Next(0, _allProducts.GetProductCount());
            for (int i = 0; i < customersCount; i++)
            {
                Customer customer = new Customer(Random.Next(0, maxMoney));
                for (int j = 0; j < customerProductsCount; j++)
                {
                    int productId = Random.Next(0, _allProducts.ProductCount);
                    customer.AddToBasked(_allProducts.GetProduct(productId));
                }

                _customers.Enqueue(customer);
            }
        }

        public Customer GetCustomer()
        {
            return _customers.Dequeue();
        }
    }

    class Customer
    {
        private int _money;
        private List<Product> _basket;

        public int Money => _money;
        public int BasketCount => _basket.Count;

        public Customer(int money)
        {
            _money = money;
            _basket = new List<Product>() { };
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

        public int SumAllProducts()
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

        public Product GetProduct(int id)
        {
            return _basket[id];
        }

        public void AddToBasked(Product product)
        {
            _basket.Add(product);
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
        public int ProductCount => _allProducts.Count;

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

        public Product GetProduct(int id)
        {
            return _allProducts[id];
        }

        public int GetProductCount()
        {
            return _allProducts.Count;
        }
    }
}