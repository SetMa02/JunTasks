using System;

namespace BDPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Player
    {
        private int _id;
        private string _nickName;
        private int _playerLevel;
        private bool _isBanned;

        public Player(int id, string nickName, int playerLevel)
        {
            _id = id;
            _nickName = nickName;
            _playerLevel = playerLevel;
            _isBanned = false;
        }
    }

    class Database
    {
        private Player[] _players;

        public Database()
        {
            _players = new Player[]{};
        }

        public void AddPlayer(Player player)
        {
            _players[_players.Length] = player;
        }

        public void BanPlayer(Player player)
        {
            
        }

        public void UnBanPlayer(Player player)
        {
            
        }

        public void DeletePlayer(Player player)
        {
            
        }
    }
}