using System;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double rubWallet;
            double usdWallet;
            double eurWallet;

            double usdCourse = 72.4;
            double eurCourse = 84.2;

            bool isExit = false;

            Console.WriteLine("Введите свои рубли: ");
            rubWallet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите свои доллары: ");
            usdWallet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите свои евро: ");
            eurWallet = Convert.ToInt32(Console.ReadLine());

            while (isExit == false)
            {
                Console.WriteLine("Какую операцию проветси?");
                Console.WriteLine("1 - конвертация рублей | 2 - конвертация долларов | 3 - конвертация евро");
                    
                string answer = Console.ReadLine();
                
                if (answer == "exit")
                    return;
                
                double amountToConvert;
                Console.WriteLine("Сколько вы хотите перевести?");
                amountToConvert = Convert.ToDouble(Console.ReadLine());

                
                
                switch (Convert.ToInt32(answer))
                {
                    case 1:
                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в доллары | 2 - в евро");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                if(rubWallet - amountToConvert < 0)
                                    return;
                                rubWallet -= amountToConvert;
                                amountToConvert /= usdCourse;
                                usdWallet += amountToConvert;
                                break;
                            case 2:
                                if(rubWallet - amountToConvert < 0)
                                    return;
                                rubWallet -= amountToConvert;
                                amountToConvert /= eurCourse;
                                eurCourse += amountToConvert;
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в рубли | 2 - в евро");
                       
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                if(usdWallet - amountToConvert < 0)
                                    return;
                                usdWallet -= amountToConvert;
                                amountToConvert *= usdCourse;
                                usdWallet += amountToConvert;
                                break;
                            case 2:
                                if(usdWallet - amountToConvert < 0)
                                    return;
                                usdWallet -= amountToConvert;
                                amountToConvert = amountToConvert * usdCourse / eurCourse;
                                usdWallet += amountToConvert;
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в рубли | 2 - в доллары");
                       
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                if(eurWallet - amountToConvert < 0)
                                    return;
                                eurWallet -= amountToConvert;
                                amountToConvert *= eurCourse;
                                eurWallet += amountToConvert;
                                break;
                            case 2:
                                if(eurWallet - amountToConvert < 0)
                                    return;
                                eurWallet -= amountToConvert;
                                amountToConvert = amountToConvert * eurCourse / usdCourse;
                                eurWallet += amountToConvert;
                                break;
                        }
                        break;
                }
                Console.WriteLine("рублей: {0} | долларов: {1} | евро: {2}", rubWallet, usdWallet, eurWallet);
            }
        }
    }
}