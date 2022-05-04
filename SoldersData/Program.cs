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
            int mounth;
            Console.WriteLine("Вводете месяц пребывания солдата: ");

            if (Int32.TryParse(Console.ReadLine(), out mounth))
            {
                army.SoldiersRequest(mounth);
            }
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

        public void SoldiersRequest(int mounth)
        {
            List<Soldier> soldiers = _soldiers.Where(soldier => soldier.ServiceTime == mounth).ToList();
            ShowSoldiers(soldiers);
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldiers.IndexOf(soldier)}. {soldier.Name}, {soldier.Title}");
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