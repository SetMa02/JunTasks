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
            Player player = new Player();

            while (isExit == false)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Просмотр товара \n" +
                                  "2 - Купить товар \n" +
                                  "3 - Заглянуть в рюкзак \n" +
                                  "4 - выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        seller.ShowItems();
                        break;
                    case "2":
                        int buyIndex;
                        Console.Clear();
                        Console.WriteLine("Какой товар хотите купить?");
                        seller.ShowItems();
                        buyIndex = Convert.ToInt32(Console.ReadLine());
                        player.AddItem(seller.SellItem(buyIndex - 1));
                        break;
                    case "3":
                        Console.Clear();
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
        }
    }

    class Player
    {
        private List<Item> _backPack;

        public Player()
        {
            _backPack = new List<Item>() { };
        }

        public void AddItem(Item item)
        {
            _backPack.Add(item);
        }

        public void ShowItems()
        {
            foreach (var item in _backPack)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    class Seller
    {
        private List<Item> _items;

        public Seller()
        {
            _items = new List<Item>()
            {
                new Item("Меч"),
                new Item("Посох"),
                new Item("Лук"),
                new Item("Щит"),
                new Item("Кинжал")
            };
        }

        public Item SellItem(int id)
        {
            Item SellItem = _items[id];
            _items.RemoveAt(id);
            return SellItem;
        }

        public void ShowItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + _items[i].Name);
            }
        }
    }

    class Item
    {
        private string _name;

        public string Name => _name;

        public Item(string name)
        {
            _name = name;
        }
    }
}