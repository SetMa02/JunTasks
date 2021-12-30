using System;
using System.Collections.Generic;

namespace BDPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            Database database = new Database();
            int id = 0;

            while (isExit == false)
            {
                Console.WriteLine();
                Console.WriteLine("1 - добавить игрока \n" +
                                  "2 - показать всех игроков \n" +
                                  "3 - удалить игрока \n" +
                                  "4 - забанить игрока \n" +
                                  "5 - разбанить игрока \n" +
                                  "6 - выход");
                switch (Console.ReadLine())
                {
                    case "1":

                        string nickName;
                        int level;

                        Console.WriteLine("Введите имя игрока:");
                        nickName = Console.ReadLine();
                        Console.WriteLine("Введите уровень игрока:");
                        level = Convert.ToInt32(Console.ReadLine());

                        Player player = new Player(0, nickName, level);
                        database.AddPlayer(player);
                        database.RewritePlayers();

                        break;
                    case "2":
                        database.ShowPlayer();
                        break;
                    case "3":
                        int deleteIndex;
                        database.ShowPlayer();
                        Console.WriteLine("Введите индекс на удаление:");
                        deleteIndex = Convert.ToInt32(Console.ReadLine());
                        database.DeletePlayers(deleteIndex);
                        break;
                    case "4":
                        int banIndex;
                        database.ShowBanStatuses(false);
                        banIndex = Convert.ToInt32(Console.ReadLine());
                        database.BanPlayer(banIndex);
                        break;
                    case "5":
                        int unBanIndex;
                        unBanIndex = Convert.ToInt32(Console.ReadLine());
                        database.UnBanPlayer(unBanIndex);
                        break;
                    case "6":
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
        private int _id;
        private string _nickName;
        private int _playerLevel;
        private bool _isBanned;

        public int Id { get; set; }
        public string NickName => _nickName;
        public int PlayerLevel => _playerLevel;
        public bool IsBanned => _isBanned;

        public Player(int id, string nickName, int playerLevel)
        {
            _id = id;
            _nickName = nickName;
            _playerLevel = playerLevel;
            _isBanned = false;
        }

        public void Ban()
        {
            _isBanned = true;
        }

        public void UnBan()
        {
            _isBanned = false;
        }
    }

    class Database
    {
        private List<Player> _players;

        public void RewritePlayers()
        {
            int newIndex = 0;
            foreach (var player in _players)
            {
                player.Id = newIndex;
                newIndex++;
            }
        }

        public Database()
        {
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void BanPlayer(int id)
        {
            _players[id].Ban();
        }

        public void UnBanPlayer(int id)
        {
            _players[id].UnBan();
        }

        public void DeletePlayers(int id)
        {
            _players.RemoveAt(id);
            RewritePlayers();
        }

        public void ShowPlayer()
        {
            foreach (var player in _players)
            {
                Console.WriteLine(player.Id + ". " + player.NickName + " " + player.IsBanned);
            }
        }

        public void ShowBanStatuses(bool status)
        {
            foreach (var databasePlayer in _players)
            {
                if (databasePlayer.IsBanned == status)
                {
                    Console.WriteLine(databasePlayer.Id + ". " + databasePlayer.NickName);
                }
            }
        }
    }
}