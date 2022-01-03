using System;
using System.Collections.Generic;

namespace TrainsTripPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            int minPassangers = 10;
            int maxPassangers = 500;

            while (isExit == false)
            {
                LogistickPreparation logistick = new LogistickPreparation(minPassangers, maxPassangers);
                logistick.CreateTrip();
                Console.WriteLine("На поездку зарегестрировались " + logistick.Passangers + " пассажиров +\n" +
                                  "Нажмите любую кнопку чтобы сформировать поезд");
                Console.ReadKey();

                TrainConstruction train = new TrainConstruction();
                train.Form(logistick.Passangers);
                Console.WriteLine();
                train.ShowCarriagesData();
                Console.WriteLine("Нажмите любую кнопку, чтобы сформировать еще поездку или exit для выхода");
                if (Console.ReadLine() == "exit")
                {
                    isExit = true;
                }
                Console.Clear();
            }
        }
    }
    class LogistickPreparation
    {
        private Random _random = new Random();
        private int _passangers;
        private string _trip;

        public int Passangers => _passangers;
        public string Trip => _trip;

        public LogistickPreparation(int minPassangers, int maxPassangers)
        {
            _passangers = _random.Next(minPassangers, maxPassangers);
        }
        public void CreateTrip()
        {
            Console.WriteLine("Точка отправления: ");
            _trip = Console.ReadLine();
            Console.WriteLine("Конечная точка:");
            _trip += "-" + Console.ReadLine();
        }
    }
    class TrainConstruction
    {
        private List<Carriage> _carriages;
        private int _lowCarriageCapacity;
        private int _mediumCarriageCapacity;
        private int _hightCarriageCapacity;
        private int _maxPassangersCountForSmallCarriages;
        private int _maxPassangersCountForMediumCarriages;
        public TrainConstruction()
        {
            _carriages = new List<Carriage>() { };
            _lowCarriageCapacity = 15;
            _mediumCarriageCapacity = 30;
            _hightCarriageCapacity = 60;
            _maxPassangersCountForMediumCarriages = 250;
            _maxPassangersCountForSmallCarriages = 100;
        }
        public void Form(int passangers)
        {
            if (passangers <= _maxPassangersCountForSmallCarriages)
            {
                CarrageCreation(_lowCarriageCapacity, CalculationCarrageCapacity(passangers, _lowCarriageCapacity));
            }
            else if (passangers <= 250 && passangers > _maxPassangersCountForMediumCarriages)
            {
                CarrageCreation(_mediumCarriageCapacity,
                    CalculationCarrageCapacity(passangers, _mediumCarriageCapacity));
            }
            else
            {
                CarrageCreation(_hightCarriageCapacity, CalculationCarrageCapacity(passangers, _hightCarriageCapacity));
            }
        }
        public void ShowCarriagesData()
        {
            Console.WriteLine("Всего вагонов - " + _carriages.Count + ". Каждый вмещает - " + _carriages[0].Capacity);
        }
        private int CalculationCarrageCapacity(int passangers, int capacity)
        {
            int carrages = passangers / capacity;
            if (passangers % capacity != 0)
            {
                carrages++;
            }
            return carrages;
        }
        private void CarrageCreation(int capacity, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Carriage carriage = new Carriage(capacity);
                _carriages.Add(carriage);
            }
        }
    }
    class Carriage
    {
        private int _capacity;
        public int Capacity => _capacity;
        public Carriage(int capacity)
        {
            _capacity = capacity;
        }
    }
}