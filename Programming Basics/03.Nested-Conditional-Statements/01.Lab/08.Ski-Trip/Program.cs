using System;

namespace SkiTrip
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int stayDays = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();
            double stayPrice = 0;
            double discount = 0;
            double endPrice = 0;
            double tip = 0;
            double totalSum = 0;

            int stayNights = stayDays - 1;

            if (roomType == "room for one person")
            {
                stayPrice = stayNights * 18.00;
                discount = 0;
                endPrice = stayPrice - discount;
                if (feedback == "positive")
                {
                    tip = (endPrice * 25) / 100;
                    totalSum = endPrice + tip;
                    Console.WriteLine($"{totalSum:F2}");
                }
                else if (feedback == "negative")
                {
                    tip = (endPrice * 10) / 100;
                    totalSum = endPrice - tip;
                    Console.WriteLine($"{totalSum:F2}");
                }
            }
            else if (roomType == "apartment")
            {
                stayPrice = stayNights * 25.00;
                if (stayDays < 10)
                {
                    discount = (stayPrice * 30) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
                else if (stayDays >= 10 && stayDays <= 15)
                {
                    discount = (stayPrice * 35) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
                else if (stayDays > 15)
                {
                    discount = (stayPrice * 50) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
            }
            else if (roomType == "president apartment")
            {
                stayPrice = stayNights * 35.00;
                if (stayDays < 10)
                {
                    discount = (stayPrice * 10) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
                else if (stayDays >= 10 && stayDays <= 15)
                {
                    discount = (stayPrice * 15) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
                else if (stayDays > 15)
                {
                    discount = (stayPrice * 20) / 100;
                    endPrice = stayPrice - discount;
                    if (feedback == "positive")
                    {
                        tip = (endPrice * 25) / 100;
                        totalSum = endPrice + tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                    else if (feedback == "negative")
                    {
                        tip = (endPrice * 10) / 100;
                        totalSum = endPrice - tip;
                        Console.WriteLine($"{totalSum:F2}");
                    }
                }
            }
        }
    }
}
