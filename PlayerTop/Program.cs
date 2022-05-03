using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerTop
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRanking gameRanking = new GameRanking();
            
            gameRanking.ShowLevelTop();

            gameRanking.ShowPowerTop();
        }
    }

    class GameRanking
    {
        private List<Player> _players;

        public GameRanking()
        {
            _players = new List<Player>()
            {
                new Player("Петров Ростислав Германович", 35, 999),
                new Player("Лихачёв Аверкий Владимирович", 25, 1500),
                new Player("Константинов Велорий Тихонович", 45, 500),
                new Player("Дементьев Феликс Евгеньевич", 55, 300),
                new Player("Блинов Богдан Петрович", 65, 2950),
                new Player("Беспалов Натан Валентинович", 15, 452),
                new Player("Беспалов Валерий Глебович", 20, 3548),
                new Player("Савин Аверкий Валентинович", 21, 5648),
                new Player("Суханов Илья Агафонович", 56, 150),
                new Player("Бобылёв Рубен Ильяович", 18, 688),
            };
            ShowPlayerTop(_players.Count);
            Console.WriteLine("");
        }

        public void ShowLevelTop()
        {
            _players = (from player in _players orderby player.Level descending select player).ToList();
            ShowPlayerTop();
        }

        public void ShowPowerTop()
        {
            _players = (from player in _players orderby player.Power descending select player).ToList();
            ShowPlayerTop();
        }

        private void ShowPlayerTop(int positions = 3)
        {
            for (int i = 0; i < positions; i++)
            {
                Console.WriteLine($"{i}. {_players[i].Name}, {_players[i].Level}, {_players[i].Power}");
            }
            Console.WriteLine("");
        }
    }
    
    class Player
    {
        private string _name;
        private int _level;
        private int _power;
        
        public string Name => _name;
        public int Level => _level;
        public int Power => _power;
        
        public Player(string name, int level, int disease)
        {
            _name = name;
            _level = level;
            _power = disease;
        }
    }
}