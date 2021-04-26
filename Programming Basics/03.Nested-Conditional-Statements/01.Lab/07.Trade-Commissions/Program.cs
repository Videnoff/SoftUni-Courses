using System;

namespace TradeCommissions
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double tradeVolume = double.Parse(Console.ReadLine());
            double comission = 0;

            if (town == "Sofia")
            {
                if (tradeVolume >= 0 && tradeVolume <= 500)
                {
                    comission = (tradeVolume * 5) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 500 && tradeVolume <= 1000)
                {
                    comission = (tradeVolume * 7) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 1000 && tradeVolume <= 10000)
                {
                    comission = (tradeVolume * 8) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 10000)
                {
                    comission = (tradeVolume * 12) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "Varna")
            {
                if (tradeVolume >= 0 && tradeVolume <= 500)
                {
                    comission = (tradeVolume * 4.5) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 500 && tradeVolume <= 1000)
                {
                    comission = (tradeVolume * 7.5) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 1000 && tradeVolume <= 10000)
                {
                    comission = (tradeVolume * 10) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 10000)
                {
                    comission = (tradeVolume * 13) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "Plovdiv")
            {
                if (tradeVolume >= 0 && tradeVolume <= 500)
                {
                    comission = (tradeVolume * 5.5) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 500 && tradeVolume <= 1000)
                {
                    comission = (tradeVolume * 8) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 1000 && tradeVolume <= 10000)
                {
                    comission = (tradeVolume * 12) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else if (tradeVolume > 10000)
                {
                    comission = (tradeVolume * 14.5) / 100;
                    Console.WriteLine($"{comission:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
