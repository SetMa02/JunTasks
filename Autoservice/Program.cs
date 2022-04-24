using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Autoservice
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            int startMoney = 5000;
            int wrokPrice = 500;
            PartsShop shop = new PartsShop();
            Autoservice autoservice = new Autoservice(startMoney, wrokPrice, shop);

            while (isExit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Что будем делать?");

                Console.WriteLine("1 - Починить машину" +
                                  "\n2 - проверить склад" +
                                  "\n3 - Сходить в Магазин" +
                                  "\n4 - Выход");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        RepairCar(autoservice);
                        break;
                    case "2":
                        autoservice.ShowStatus();
                        break;
                    case "3":
                        OpenShop(shop, autoservice);
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }

        private static void RepairCar(Autoservice autoservice)
        {
            Car car = new Car();
            autoservice.CheckNewCar(car);
        }

        private static void OpenShop(PartsShop shop, Autoservice autoservice)
        {
            shop.ShowCatalog();

            int newPArtId;

            if (Int32.TryParse(Console.ReadLine(), out newPArtId))
            {
                shop.BuyPart(autoservice, newPArtId);
            }
        }
    }

    class Autoservice
    {
        private Storge _storge;
        private int _money;
        private int _workPrice;
        private PartsShop _shop;

        public int Money => _money;

        public Autoservice(int money, int workPrice, PartsShop shop)
        {
            _storge = new Storge();
            _money = money;
            _workPrice = workPrice;
            _shop = shop;
        }

        public void CheckNewCar(Car car)
        {
            Console.WriteLine("Новая машина с поломкой!");
            Console.WriteLine($"У нее сломано {car.BrokenPart.Name}");
            Console.WriteLine("Какую детать будем менять?");
            _storge.ShowStorage();
            int partId;
            
            if (Int32.TryParse(Console.ReadLine(), out partId))
            {
                RepairCar(car, partId, _shop);
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Баланс: {_money}");
            _storge.ShowStorage();
        }

        public void AddMoney(int moneyAmount)
        {
            _money += moneyAmount;
        }

        public void ReduceMoney(int reduceAmount)
        {
            _money -= reduceAmount;
        }

        public void RefillStorage(Part part)
        {
            _storge.AddPart(part);
        }

        private void RepairCar(Car car, int partId, PartsShop shop)
        {
            if (_storge.GetPart(partId) != null)
            {
                if (car.BrokenPart.Name == _storge.GetPart(partId).Name)
                {
                    Console.Clear();
                    Console.WriteLine("Ремонт успешен!");
                    Console.WriteLine("Заменена " + car.BrokenPart.Name);
                    Console.WriteLine($"Ваша награда {shop.GetPartPrice(partId) + _workPrice}");
                    AddMoney(shop.GetPartPrice(partId) + _workPrice);
                    _storge.RemovePart(_storge.GetPart(partId));
                }
                else
                {
                    Console.WriteLine("Деталь не подходит, вы заплатили штраф " + _workPrice);
                }
            }
        }
    }

    class PartsShop
    {
        private List<Part> _parts;
        private List<int> _price;

        public PartsShop()
        {
            _parts = new List<Part>() { };
            _price = new List<int>() { };
            _parts.Add(new Part("Деталь №1"));
            _parts.Add(new Part("Деталь №2"));
            _parts.Add(new Part("Деталь №3"));
            _parts.Add(new Part("Деталь №4"));
            _parts.Add(new Part("Деталь №5"));
            _parts.Add(new Part("Деталь №6"));
            _price.Add(250);
            _price.Add(1250);
            _price.Add(500);
            _price.Add(700);
            _price.Add(2000);
            _price.Add(940);
        }

        public int GetPartPrice(int partId)
        {
            return _price[partId];
        }

        public void ShowCatalog()
        {
            foreach (var part in _parts)
            {
                Console.WriteLine(_parts.IndexOf(part) + ". " + part.Name + " цена - " + _price[_parts.IndexOf(part)]);
            }
        }

        public void BuyPart(Autoservice autoservice, int partId)
        {
            if (_parts.Count - 1 >= partId && partId >= 0 && autoservice.Money >= _price[partId])
            {
                autoservice.ReduceMoney(_price[partId]);
                autoservice.RefillStorage(_parts[partId]);
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }

    class Storge
    {
        private List<Part> _parts;

        public Storge()
        {
            _parts = new List<Part>() { };
        }

        public Part GetPart(int i)
        {
            if (_parts.Contains(_parts[i]))
            {
                return _parts[i];
            }
            else
            {
                Console.WriteLine("Такой детали нет");
                return null;
            }
        }

        public void AddPart(Part part)
        {
            _parts.Add(part);
        }

        public bool RemovePart(Part part)
        {
            if (_parts.Contains(part))
            {
                _parts.Remove(part);
                return true;
            }
            else
            {
                Console.WriteLine("Такой детали нет на складе");
                return false;
            }
        }

        public void ShowStorage()
        {
            foreach (var part in _parts)
            {
                Console.WriteLine(_parts.IndexOf(part) + ". " + part.Name);
            }
        }
    }

    class Part
    {
        private string _name;
        public string Name => _name;

        public Part(string name)
        {
            _name = name;
        }
    }

    class Car
    {
        private Part _brokenPart;
        private Random _random;

        public Part BrokenPart => _brokenPart;

        public Car()
        {
            _random = new Random();
            BrokeCar();
        }

        private void BrokeCar()
        {
            int brokenPart = _random.Next(1, 6);
            _brokenPart = new Part("Деталь №" + brokenPart);
        }
    }
}