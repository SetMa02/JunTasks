using System;

namespace SuperMarketAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            
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

        public void CreateProduct()
        {
            
        }
    }
}