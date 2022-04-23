using System;

namespace ZooPark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }

    class Zoo
    {
        
    }

    class Aviary
    {
        
    }

    class Animal
    {
        private bool _gender;
        private string _sound;

        public Animal(bool gender, string sound)
        {
            _gender = gender;
            _sound = sound;
        }

        public void GetSound()
        {
            Console.WriteLine(_sound);
        }

        public void GetGender()
        {
            if (_gender == true)
            {
                Console.WriteLine("Мальчик");
            }
            else
            {
                Console.WriteLine("Девочка");
            }
        }
    }
}