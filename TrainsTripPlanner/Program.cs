using System;
using System.Collections.Generic;

namespace TrainsTripPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            
            while (isExit == false)
            {
                LogistickPreparation logistick = new LogistickPreparation();
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

        public LogistickPreparation()
        {
            _passangers = _random.Next(10, 500);
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
        private int _MediumCarriageCapacity;
        private int _HightCarriageCapacity;
        
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
        
        public TrainConstruction()
        {
            _carriages = new List<Carriage>() { };
            _lowCarriageCapacity = 15;
            _MediumCarriageCapacity = 30;
            _HightCarriageCapacity = 60;
        }

        public void Form(int passangers)
        {
            if (passangers <= 100)
            {
                CarrageCreation(_lowCarriageCapacity, CalculationCarrageCapacity(passangers,_lowCarriageCapacity));
            }
            else if(passangers <= 250 && passangers > 100)
            {
                CarrageCreation(_MediumCarriageCapacity, CalculationCarrageCapacity(passangers,_MediumCarriageCapacity));
            }
            else
            {
                CarrageCreation(_HightCarriageCapacity, CalculationCarrageCapacity(passangers,_HightCarriageCapacity));
            }
        }

        public void ShowCarriagesData()
        {
            Console.WriteLine("Всего вагонов - " + _carriages.Count+ ". Каждый вмещает - " + _carriages[0].Capacity);
        }
    }
    
    class Carriage
    {
        private int _capacity;
        public int Capacity=> _capacity;

        public Carriage(int capacity)
        {
            _capacity = capacity;
        }
    }
}