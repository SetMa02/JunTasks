using System;

namespace GrannysQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGrannys;
            int timeOfReceipt = 10;
            int minutesAtHour = 60;

            Console.WriteLine("Введите кол-во старушек: ");
            numberOfGrannys = Convert.ToInt32(Console.ReadLine());

            int totalMinutes = numberOfGrannys * timeOfReceipt;
            int hourBeforeAdmission = totalMinutes / minutesAtHour;
            int minutesBeforeAdmission = totalMinutes % minutesAtHour;

            Console.WriteLine("Вы должны отстоять в очереди "+ hourBeforeAdmission +" часа и "+ minutesBeforeAdmission +" минут." );
        }
    }
}