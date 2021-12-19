using System;

namespace PlayerClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.ShowStatus();
        }
    }

    class Player
    {
        private string name;
        private string speciality;

        public Player()
        {
            name = "SetMa02";
            speciality = "маг";
        }

        public  void ShowStatus()
        {
            Console.WriteLine(this.name + " " + this.speciality);
        }
    }
}