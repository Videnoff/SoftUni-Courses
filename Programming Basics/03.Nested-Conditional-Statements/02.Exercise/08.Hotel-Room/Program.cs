using System;

namespace HotelRoom
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int stayCount = int.Parse(Console.ReadLine());
            double apartmentPrice = 0.0;
            double studioPrice = 0.0;
            double apartmentDiscount = 0.0;
            double studioDiscount = 0.0;

            if (month == "May" || month == "October")
            {
                apartmentPrice = stayCount * 65;
                if (stayCount > 14)
                {
                    apartmentDiscount = apartmentPrice * 10 / 100;
                }
                studioPrice = stayCount * 50;
                if (stayCount > 7 && stayCount <= 14)
                {
                    studioDiscount = studioPrice * 5 / 100;
                }
                else if (stayCount > 14)
                {
                    studioDiscount = studioPrice * 30 / 100;
                }
            }
            else if (month == "June" || month == "September")
            {
                apartmentPrice = stayCount * 68.70;
                if (stayCount > 14)
                {
                    apartmentDiscount = apartmentPrice * 10 / 100;
                }
                studioPrice = stayCount * 75.20;
                if (stayCount > 14)
                {
                    studioDiscount = studioPrice * 20 / 100;
                }
            }
            else if (month == "July" || month == "August")
            {
                apartmentPrice = stayCount * 77;
                if (stayCount > 14)
                {
                    apartmentDiscount = apartmentPrice * 10 / 100;
                }
                studioPrice = stayCount * 76;
            }

            double totalApartmentPrice = apartmentPrice - apartmentDiscount;
            double totalStudioPrice = studioPrice - studioDiscount;

            Console.WriteLine($"Apartment: {totalApartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:F2} lv.");
        }
    }
}
