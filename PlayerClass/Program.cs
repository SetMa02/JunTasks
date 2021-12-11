using System;

namespace PlayerClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            
            Player.ShowStatus(player);
        }
    }

    class Player
    {
        private string name;
        private string playerClass;

        public Player()
        {
            name = "SetMa02";
            playerClass = "маг";
        }

        public static void ShowStatus(Player player)
        {
            Console.WriteLine(player.name + " " + player.playerClass);
        }
    }
}