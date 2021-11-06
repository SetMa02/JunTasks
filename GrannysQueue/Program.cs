using System;

namespace GrannysQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGrannys;
            int timeOfReceipt = 10;

            Console.WriteLine("Введите кол-во старушек: ");
            numberOfGrannys = Convert.ToInt32(Console.ReadLine());

            int totalMinutes = numberOfGrannys * timeOfReceipt;
            int minutesBeforeAdmission = totalMinutes % 60;

            Console.WriteLine("Вы должны отстоять в очереди "+ (totalMinutes / 60) +" часа и "+ minutesBeforeAdmission +" минут." );
        }
    }
}