using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Detectives
{
    class Program
    {
        static void Main(string[] args)
        {
            PoliceDataBase policeDataBase = new PoliceDataBase();

            policeDataBase.ShowAllCriminals();

            policeDataBase.SearchCriminals();
        }
    }

    class PoliceDataBase
    {
        private List<Criminal> _criminals;

        public PoliceDataBase()
        {
            _criminals = new List<Criminal>()
            {
                new Criminal("Зубенко Михаил Петрович", false, 90, 175, "Славян"),
                new Criminal("Евсеев Пантелей Еремеевич", true, 120, 168, "Казак"),
                new Criminal("Васильев Георгий Мэлорович", false, 97, 182, "Турок"),
                new Criminal("Кудрявцев Владлен Владиславович", false, 85, 160, "Хакас"),
                new Criminal("Панфилов Любовь Тихонович", true, 78, 181, "Казак"),
                new Criminal("Романов Авраам Викторович", false, 100, 169, "Чеченец"),
                new Criminal("Игнатьев Евдоким Геласьевич", false, 99, 171, "Турок"),
                new Criminal("Ковалёв Юлиан Федорович", false, 77, 170, "Хакас"),
                new Criminal("Голубев Платон Тихонович", true, 60, 170, "Турок"),
                new Criminal("Казаков Платон Созонович", false, 80, 185, "Казак"),
                new Criminal("Герасимова Рамина Мэлсовна", true, 60, 175, "Тувинец"),
                new Criminal("Тетерина Божена Арсеньевна", true, 70, 168, "Чеченец"),
                new Criminal("Чернова Луиза Адольфовна", false, 65, 170, "Тувинец"),
                new Criminal("Галкина Анжела Аркадьевна", false, 90, 155, "Славян"),
                new Criminal("Игнатова Властилина Онисимовна", false, 88, 160, "Тувинец"),
            };
        }

        public void ShowAllCriminals()
        {
            foreach (var criminal in _criminals)
            {
                Console.WriteLine($"{_criminals.IndexOf(criminal)}. {criminal.Name}");
            }
        }

        public void SearchCriminals()
        {
            int weight = 0;
            int height = 0;
            string national = "";
            Console.WriteLine("Введите вес:");
            
            if (Int32.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Введите рост:");
                if (Int32.TryParse(Console.ReadLine(), out height))
                {
                    Console.WriteLine("Введите национальность:");
                    national = Console.ReadLine();
                }
            }

            List<Criminal> result;

            if (weight != 0 && height != 0 && national != "")
            {
                result = _criminals
                    .Where(x => x.Weight == weight && x.Height == height && x.National == national &&
                                x.IsCaged == false).ToList();

                Console.WriteLine(result.Count);

                foreach (var criminal in result)
                {
                    Console.WriteLine(criminal.Name);
                }
            }
        }
    }

    class Criminal
    {
        private string _name;
        private bool _isCaged;
        private int _height;
        private int _weight;
        private string _national;

        public string Name => _name;
        public bool IsCaged => _isCaged;
        public int Height => _height;
        public int Weight => _weight;
        public string National => _national;

        public Criminal(string name, bool isCaged, int weight, int height, string national)
        {
            _name = name;
            _isCaged = isCaged;
            _height = height;
            _weight = weight;
            _national = national;
        }
    }
}