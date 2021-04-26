using System;

namespace SummerOutfit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int grads = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (dayTime == "Morning")
            {
                if (grads >= 10 && grads <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (grads > 18 && grads <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (grads >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (dayTime == "Afternoon")
            {
                if (grads >= 10 && grads <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (grads > 18 && grads <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (grads >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else if (dayTime == "Evening")
            {
                if (grads >= 10 && grads <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (grads > 18 && grads <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (grads >= 25)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {grads} degrees, get your {outfit} and {shoes}.");
        }
    }
}
