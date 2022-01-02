using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;

            Seller seller = new Seller();

            Player player = new Player(300);

            while (isExit == false)
            {
                Console.WriteLine("Денег - " + player.Money);
                Console.WriteLine();
                Console.WriteLine("1 - Просмотр товара \n" +
                                  "2 - Купить товар \n" +
                                  "3 - Заглянуть в рюкзак \n" +
                                  "4 - выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        seller.ShowItems();
                        break;
                    case "2":
                        BuyItem();
                        break;
                    case "3":
                        player.ShowItems();
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Невверный ввод!");
                        break;
                }
            }

            void BuyItem()
            {
                int buyIndex;
                Console.Clear();
                Console.WriteLine("Какой товар хотите купить?");
                seller.ShowItems();
                if (!Int32.TryParse(Console.ReadLine(), out buyIndex))
                {
                    Console.WriteLine("Неверный индекс!");
                    BuyItem();
                }
                else
                {
                    player.AddItem(seller.SellItem(buyIndex - 1));
                }
            }
        }
    }

    class Profile
    {
        protected List<Item> Items;

        public Profile(List<Item> items)
        {
            Items = items;
        }

        public void ShowItems()
        {
            Console.WriteLine();
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + Items[i].Name + " - " + Items[i].Cost);
            }
        }
    }

    class Player : Profile
    {
        private int _money;
        public int Money => _money;

        public Player(int money) : base(new List<Item>())
        {
            _money = money;
        }

        public void AddItem(Item item)
        {
            if (_money - item.Cost >= 0)
            {
                _money -= item.Cost;
                Items.Add(item);
            }
            else
            {
                Console.WriteLine("Недостаточно денег!");
            }
        }
    }

    class Seller : Profile
    {
        public Seller() : base(new List<Item>()
        {
            new Item("Меч", 100),
            new Item("Посох", 150),
            new Item("Лук", 75),
            new Item("Щит", 125),
            new Item("Кинжал", 50)
        })
        {
        }

        public Item SellItem(int id)
        {
            Item sellItem = Items[id];
            Items.RemoveAt(id);
            return sellItem;
        }
    }

    class Item
    {
        private string _name;
        private int _cost;

        public string Name => _name;
        public int Cost => _cost;

        public Item(string name, int cost)
        {
            _name = name;
            _cost = cost;
        }
    }
}