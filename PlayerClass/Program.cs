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
        private string _name;
        private string _speciality;

        public Player()
        {
            _name = "SetMa02";
            _speciality = "маг";
        }

        public  void ShowStatus()
        {
            Console.WriteLine(_name + " " + _speciality);
        }
    }
}