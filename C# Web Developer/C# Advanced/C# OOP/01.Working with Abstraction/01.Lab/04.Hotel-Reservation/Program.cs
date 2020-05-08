using System;

namespace _04.Hotel_Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new PriceCalculator();

            var input = Console.ReadLine().Split();

            var pricePerDay = decimal.Parse(input[0]);
            var days = int.Parse(input[1]);
            var season = input[2].ToLower();
            var discount = "none";

            if (input.Length > 3)
            {
                discount = input[3].ToLower();
            }

            var price = calculator.Calculate(pricePerDay, days, season: Enum.Parse<Season>(season),Enum.Parse<Discount>(discount));

            Console.WriteLine($"{price:F2}");
        }
    }
}
