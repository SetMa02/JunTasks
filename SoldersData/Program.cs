using System;
using System.Collections.Generic;
using System.Linq;

namespace SoldersData
{
    class Program
    {
        static void Main(string[] args)
        {
            Platoon platoon = new Platoon();

            platoon.CreateRequest();
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers;
        private List<ArmyData> _armyDatas;

        public Platoon()
        {
            _armyDatas = new List<ArmyData>();

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
            foreach (var soldier in _soldiers)
            {
                ArmyData armyData = new ArmyData(soldier.Name, soldier.Title);
                _armyDatas.Add(armyData);
            }

            ShowArmyData(_armyDatas);
        }

        private void ShowArmyData(List<ArmyData> armyDatas)
        {
            foreach (var armyData in armyDatas)
            {
                Console.WriteLine($"{armyDatas.IndexOf(armyData)}. {armyData.Name}, {armyData.Title}");
            }
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(
                    $"{soldiers.IndexOf(soldier)}. {soldier.Name}, {soldier.Title}, {soldier.ServiceTime}");
            }
        }
    }

    class ArmyData
    {
        private string _name;
        private string _title;

        public string Name => _name;
        public string Title => _title;

        public ArmyData(string name, string title)
        {
            _name = name;
            _title = title;
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