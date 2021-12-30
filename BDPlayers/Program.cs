﻿using System;
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
                        AddPlayer();
                        break;
                    case "2":
                        database.ShowPlayers();
                        break;
                    case "3":
                        DeletePlayer();
                        break;
                    case "4":
                       BanPlayer();
                        break;
                    case "5":
                        UnBanPlayer();
                        break;
                    case "6":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Невверный ввод!");
                        break;
                }
                
            }

            void AddPlayer()
            {
                string nickName;
                int level;

                Console.WriteLine("Введите имя игрока:");
                nickName = Console.ReadLine();
                Console.WriteLine("Введите уровень игрока:");
                if (!Int32.TryParse(Console.ReadLine(), out level))
                {
                    Console.Clear();
                    Console.WriteLine("Неправильный ввод!");
                    AddPlayer();
                }
                else
                {
                    Player player = new Player(0, nickName, level);
                    database.AddPlayer(player);
                    database.RewritePlayers();
                }
            }

            void DeletePlayer()
            {
                int deleteIndex;
                database.ShowPlayers();
                Console.WriteLine("Введите индекс на удаление:");
                deleteIndex = Convert.ToInt32(Console.ReadLine());
                database.DeletePlayer(deleteIndex);
            }

            void BanPlayer()
            {
                int banIndex;
                database.ShowBanStatuses(false);
                if (!Int32.TryParse(Console.ReadLine(), out banIndex))
                {
                    Console.Clear();
                    Console.WriteLine("Неверный ввод!");
                    BanPlayer();
                }
                else
                {
                    database.BanPlayer(banIndex);
                }
               
            }

            void UnBanPlayer()
            {
                int unBanIndex;
                if (!Int32.TryParse(Console.ReadLine(), out unBanIndex))
                {
                    Console.Clear();
                    Console.WriteLine("Неверный ввод!");
                    UnBanPlayer();
                }
                else
                {
                    database.UnBanPlayer(unBanIndex);
                }
                
            }
        }
    }

    class Player
    {
        private int _index;
        private string _nickName;
        private int _playerLevel;
        private bool _isBanned;

        public int Index => _index;
        public string NickName => _nickName;
        public int PlayerLevel => _playerLevel;
        public bool IsBanned => _isBanned;

        public Player(int index, string nickName, int playerLevel)
        {
            _index = index;
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

        public void SetIndex(int newIndex)
        {
            _index = newIndex;
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
                player.SetIndex(newIndex);
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

        public void DeletePlayer(int id)
        {
            _players.RemoveAt(id);
            RewritePlayers();
        }

        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                Console.WriteLine(player.Index + ". " + player.NickName + " " + player.IsBanned);
            }
        }

        public void ShowBanStatuses(bool status)
        {
            foreach (var databasePlayer in _players)
            {
                if (databasePlayer.IsBanned == status)
                {
                    Console.WriteLine(databasePlayer.Index + ". " + databasePlayer.NickName);
                }
            }
        }
    }
}