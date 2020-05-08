using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Hotel_Reservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount = Discount.None)
        {
            var price = days * pricePerDay * (int)season;

            price -= (int) discount * price / 100;

            return price;
        }
    }
}
