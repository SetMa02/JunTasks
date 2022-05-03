using System;
using System.Collections.Generic;
using System.Linq;

namespace AmnistiaArstotska
{
    class Program
    {
        static void Main(string[] args)
        {
            AristotskaGovernment aristotskaGovernment = new AristotskaGovernment();

            aristotskaGovernment.ShowCrimenals();

            aristotskaGovernment.Amnistia("Антиправительственное");

            Console.WriteLine("");

            aristotskaGovernment.ShowCrimenals();
        }
    }

    class AristotskaGovernment
    {
        private List<Criminal> _criminals;

        public AristotskaGovernment()
        {
            _criminals = new List<Criminal>()
            {
                new Criminal("Никитин Борис Максович", "Убийство"),
                new Criminal("Волков Аскольд Станиславович", "Кража"),
                new Criminal("Григорьев Овидий Валентинович", "Мошенничество"),
                new Criminal("Михеев Эдуард Владиславович", "Антиправительственное"),
                new Criminal("Белов Вилен Лукьевич", "Экстремизм"),
                new Criminal("Соболев Аверьян Богуславович", "Побои"),
                new Criminal("Шаров Мирон Георгьевич", "Антиправительственное"),
                new Criminal("Николаев Виталий Пётрович", "Мародерстов"),
                new Criminal("Мишин Влас Тарасович", "Убийство"),
                new Criminal("Петухов Венедикт Гордеевич", "Антиправительственное"),
                new Criminal("Карпов Альберт Куприянович", "Убийство")
            };
        }

        public void Amnistia(string crime)
        {
            _criminals = _criminals.Where(x => x.Crime != crime).ToList();
        }

        public void ShowCrimenals()
        {
            foreach (var criminal in _criminals)
            {
                Console.WriteLine($"{_criminals.IndexOf(criminal)}. {criminal.Name}");
            }
        }
    }

    class Criminal
    {
        private string _name;
        private string _crime;

        public string Name => _name;
        public string Crime => _crime;

        public Criminal(string name, string crime)
        {
            _name = name;
            _crime = crime;
        }
    }
}