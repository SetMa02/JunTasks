using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace ZooPark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int maxAnimalCount = 5;
            bool isExit = false;

            Zoo zoo = new Zoo(5);
            zoo.CreateAviary("Обезьяний дом", "мартышка", "Уаа-Уаа!");
            zoo.CreateAviary("Тигриная скала", "тигр", "Арррр!");
            zoo.CreateAviary("Лягушачий пруд", "лягошка", "ква");
            zoo.CreateAviary("Вольчя опушка", "волк", "ауф");

            while (isExit == false)
            {
                Console.Clear();
                zoo.ShowAviaries();
                string chossedAviary = Console.ReadLine();
                if (chossedAviary == "exit")
                {
                    isExit = true;
                }
                else
                {
                    int currentAviary;
                    if (Int32.TryParse(chossedAviary, out currentAviary))
                    {
                        zoo.GoToAviary(currentAviary);
                        Console.ReadLine();
                    }
                }
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;
        private Random _random;
        private int _maxAnimalsCount;

        public Zoo(int maxAnimalsCount)
        {
            _aviaries = new List<Aviary>() { };
            _maxAnimalsCount = maxAnimalsCount;
            _random = new Random();
        }

        public void ShowAviaries()
        {
            Console.WriteLine($"Всего в зоопарке {_aviaries.Count} вольеров в какой заглянем?:");

            foreach (var aviary in _aviaries)
            {
                Console.WriteLine($"{_aviaries.IndexOf(aviary) + 1}. {aviary.Name}");
            }
        }

        public void CreateAviary(string aviaryName, string animalName, string animalSound)
        {
            Aviary aviary = new Aviary(aviaryName);

            for (int i = 0; i < _random.Next(1, _maxAnimalsCount); i++)
            {
                aviary.CreateAnimal(animalName, animalSound, _random.Next(-1, 2));
            }

            _aviaries.Add(aviary);
        }

        public void GoToAviary(int aviaryId)
        {
            if (aviaryId - 1 >= _aviaries.Count)
            {
                Console.WriteLine("Такого вольера нет(");
            }
            else
            {
                _aviaries[aviaryId - 1].ShowAnimals();
            }
        }
    }

    class Aviary
    {
        private string _name;
        private List<Animal> _animals;

        public string Name => _name;

        public Aviary(string name)
        {
            _name = name;
            _animals = new List<Animal>() { };
        }

        public void ShowAnimals()
        {
            Console.WriteLine($"В этом вольере находятся {_animals.Count} зверей:");

            foreach (var animal in _animals)
            {
                Console.Write($"{_animals.IndexOf(animal) + 1}. ");
                animal.GetName();
                Console.Write(" издает звук: ");
                animal.GetSound();
                Console.Write(" и это: ");
                animal.GetGender();
                Console.WriteLine();
            }
        }

        public void CreateAnimal(string animalName, string sound, int genderId)
        {
            bool gender;

            if (genderId == 1)
            {
                gender = false;
            }
            else
            {
                gender = true;
            }

            _animals.Add(new Animal(animalName, sound, gender));
        }
    }

    class Animal
    {
        private string _name;
        private bool _gender;
        private string _sound;

        public Animal(string name, string sound, bool gender)
        {
            _gender = gender;
            _sound = sound;
            _name = name;
        }

        public void GetName()
        {
            Console.Write(_name);
        }

        public void GetSound()
        {
            Console.Write(_sound);
        }

        public void GetGender()
        {
            if (_gender == true)
            {
                Console.Write("Мальчик");
            }
            else
            {
                Console.Write("Девочка");
            }
        }
    }
}