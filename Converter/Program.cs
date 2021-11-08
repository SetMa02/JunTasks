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

            double usdToRub = 72.4;
            double eurToRub = 84.2;

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

                double amountToConvert = 0;

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":

                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в доллары | 2 - в евро");

                        switch (Console.ReadLine())
                        {
                            case "1":

                                Console.WriteLine("Сколько вы хотите перевести?");
                                amountToConvert = Convert.ToDouble(Console.ReadLine());
                                if (rubWallet - amountToConvert < 0)
                                {
                                    Console.WriteLine("Недостаточно сресдтв");
                                    break;
                                }
                                
                                rubWallet -= amountToConvert;
                                usdWallet += amountToConvert / usdToRub;
                                
                                break;
                            case "2":
                                Console.WriteLine("Сколько вы хотите перевести?");
                                amountToConvert = Convert.ToDouble(Console.ReadLine());
                                if (rubWallet - amountToConvert < 0)
                                {
                                    Console.WriteLine("Недостаточно сресдтв");
                                    break;
                                }

                                rubWallet -= amountToConvert;
                                eurToRub += amountToConvert / eurToRub;
                                break;
                            default:
                                Console.WriteLine("Не верный ввод");
                                break;
                        }

                        break;
                    case "2":

                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в рубли | 2 - в евро");

                        switch (Console.ReadLine())
                        {
                            case "1":

                                Console.WriteLine("Сколько вы хотите перевести?");
                                amountToConvert = Convert.ToDouble(Console.ReadLine());
                                if (usdWallet - amountToConvert < 0)
                                {
                                    Console.WriteLine("Недостаточно сресдтв");
                                    break;
                                }
                                
                                usdWallet -= amountToConvert;
                                usdWallet += amountToConvert * usdToRub;
                                break;
                            case "2":

                                Console.WriteLine("Сколько вы хотите перевести?");
                                amountToConvert = Convert.ToDouble(Console.ReadLine());
                                if (usdWallet - amountToConvert < 0)
                                {
                                    Console.WriteLine("Недостаточно сресдтв");
                                    break;
                                }
                                
                                usdWallet -= amountToConvert;
                                usdWallet += amountToConvert * usdToRub / eurToRub;
                                break;
                            default:
                                Console.WriteLine("Не верный ввод");
                                break;
                        }

                        break;
                    case "3":

                        Console.WriteLine("В какую валюту конвертировать?");
                        Console.WriteLine("1 - в рубли | 2 - в доллары");

                        switch (Console.ReadLine())
                        {
                            case "1":

                                Console.WriteLine("Сколько вы хотите перевести?");
                                amountToConvert = Convert.ToDouble(Console.ReadLine());
                                if (eurWallet - amountToConvert < 0)
                                {
                                    Console.WriteLine("Недостаточно сресдтв");
                                    break;
                                }
                                
                                eurWallet -= amountToConvert;
                                eurWallet += amountToConvert * eurToRub;
                                
                                break;
                            case "2":
                                if (eurWallet - amountToConvert < 0)
                                    return;
                                
                                eurWallet -= amountToConvert;
                                eurWallet += amountToConvert * eurToRub / usdToRub;
                                break;
                            default:
                                Console.WriteLine("Не верный ввод");
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }

                Console.WriteLine("рублей: {0} | долларов: {1} | евро: {2}", rubWallet, usdWallet, eurWallet);
            }
        }
    }
}