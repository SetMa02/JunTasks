using System;

namespace PlayerClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            
        }
    }

    class Player
    {
        public string name;
        public string speciality;

        public Player()
        {
            name = "SetMa02";
            speciality = "маг";
        }
    }
}