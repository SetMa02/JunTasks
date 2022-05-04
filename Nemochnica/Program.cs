using System;
using System.Collections.Generic;
using System.Linq;

namespace Nemochnica
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinik clinik = new Clinik();
            bool isExit = false;
            Console.WriteLine("");
            
            while (isExit == false)
            {
                Console.WriteLine("1. Сортировка по ФИО\n" +
                                  "2. Сортировка по возрасту\n" +
                                  "3. Вывод с определенным заболеванием\n" +
                                  "4. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        clinik.SortName();
                        break;
                    case "2":
                        clinik.SortAge();
                        break;
                    case "3":
                        InputDiseas(clinik);
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
        
        private static void InputDiseas(Clinik clinik)
        {
            string diseas;
            Console.WriteLine("Введите заболевание:");
            diseas = Console.ReadLine();
            clinik.ShowPatioentWithDisease(diseas);
        }
    }

    class Clinik
    {
        private List<Patient> _patients;

        public Clinik()
        {
            _patients = new List<Patient>()
            {
                new Patient("Петров Ростислав Германович", 35, "Коронавирус"),
                new Patient("Лихачёв Аверкий Владимирович", 25, "Простуда"),
                new Patient("Константинов Велорий Тихонович", 45, "Грипп"),
                new Patient("Дементьев Феликс Евгеньевич", 55, "Коронавирус"),
                new Patient("Блинов Богдан Петрович", 65, "Увечья"),
                new Patient("Беспалов Натан Валентинович", 15, "Инсульт"),
                new Patient("Беспалов Валерий Глебович", 20, "Грипп"),
                new Patient("Савин Аверкий Валентинович", 21, "Коронавирус"),
                new Patient("Суханов Илья Агафонович", 56, "Рак"),
                new Patient("Бобылёв Рубен Ильяович", 18, "Коронавирус"),
            };
            
            ShowPatients(_patients);
        }

        public void SortName()
        {
            _patients = (from patient in _patients orderby patient.Name select patient).ToList();
            ShowPatients(_patients);
        }

        public void SortAge()
        {
            _patients = (from patient in _patients orderby patient.Age select patient).ToList();
            ShowPatients(_patients);
        }

        public void ShowPatioentWithDisease(string diseaes)
        {
            List<Patient> result = _patients.Where(pattient => pattient.Diseas == diseaes).ToList();
            ShowPatients(result);
        }

        private void ShowPatients(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"{_patients.IndexOf(patient)}. {patient.Name}, {patient.Diseas}");
            }
        }
    }

    class Patient
    {
        private string _name;
        private int _age;
        private string _disease;

        public string Name => _name;
        public int Age => _age;
        public string Diseas => _disease;

        public Patient(string name, int age, string disease)
        {
            _name = name;
            _age = age;
            _disease = disease;
        }
    }
}