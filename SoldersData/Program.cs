using System;
using System.Collections.Generic;
using System.Linq;

namespace SoldersData
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();
            army.CreateRequest();
        }
    }

    class Army
    {
        private List<Soldier> _soldiers;
        public Army()
        {
            _soldiers = new List<Soldier>()
            {
                new Soldier("Петров Денис", "Прапор", 2),
                new Soldier("Николаев Гарри", "Ефрейтор", 4),
                new Soldier("Давыдов Игорь", "Рядовой", 8),
                new Soldier("Кошелев Нелли", "Старлей", 12),
                new Soldier("Елисеев Николай", "Старшина", 6),
                new Soldier("Михеев Любомир", "Прапор", 7),
                new Soldier("Маслов Роберт", "Ы", 15),
                new Soldier("Ершов Юрий", "Капитан", 24),
            };

            ShowSoldiers(_soldiers);

            Console.WriteLine("");
        }

        public void CreateRequest()
        {
            var result = (from soldier in _soldiers select new {name = soldier.Name, titel = soldier.Title}).ToList();
            foreach (var soldier in result)
            {
                Console.WriteLine($"{result.IndexOf(soldier)}. {soldier.name}, {soldier.titel}");
            }
        }
        

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldiers.IndexOf(soldier)}. {soldier.Name}, {soldier.Title}, {soldier.ServiceTime}");
            }
        }
    }

    class Soldier
    {
        private string _name;
        private string _title;
        private int _serviceTime;

        public string Name => _name;
        public string Title => _title;
        public int ServiceTime => _serviceTime;

        public Soldier(string name, string title, int serviceTime)
        {
            _name = name;
            _title = title;
            _serviceTime = serviceTime;
        }
    }
}