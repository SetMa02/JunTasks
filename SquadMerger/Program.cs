using System;
using System.Collections.Generic;
using System.Linq;

namespace SquadMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();
            
            army.MergeSquads();
        }
    }
    
    class Army
    {
        private List<Soldier> _squad1;
        private List<Soldier> _squad2;

        public Army()
        {
            _squad2 = new List<Soldier>() { };
            
            _squad1 = new List<Soldier>()
            {
                new Soldier("Петров Денис"),
                new Soldier("Николаев Гарри"),
                new Soldier("Бородино Игорь"),
                new Soldier("Билан Нелли"),
                new Soldier("Боров Николай"),
                new Soldier("Михеев Любомир"),
                new Soldier("Маслов Роберт"),
                new Soldier("Ершов Юрий"),
            };

            ShowSoldiers(_squad1);

            Console.WriteLine("");
        }

        public void MergeSquads()
        {
            _squad2.AddRange(_squad1.Where(soldier => soldier.Name[0] == 'Б'));
            
            _squad1.RemoveAll(soldier => soldier.Name[0] == 'Б');
            
            ShowSoldiers(_squad1);
            
            Console.WriteLine("");

            ShowSoldiers(_squad2);
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldiers.IndexOf(soldier)}. {soldier.Name}");
            }
        }
    }
    
    class Soldier
    {
        private string _name;
        public string Name => _name;
        
        public Soldier(string name)
        {
            _name = name;

        }
    } 
}