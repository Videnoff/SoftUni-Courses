using System;

namespace SushiTime
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int plates = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());

            double price = 0.0;
            double delivery = 0.0;

            if (restaurant == "Sushi Zone")
            {
                if (type == "sashimi")
                {
                    price = plates * 4.99;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "maki")
                {
                    price = plates * 5.29;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "uramaki")
                {
                    price = plates * 5.99;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "temaki")
                {
                    price = plates * 4.29;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
            }
            else if (restaurant == "Sushi Time")
            {
                if (type == "sashimi")
                {
                    price = plates * 5.49;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "maki")
                {
                    price = plates * 4.69;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "uramaki")
                {
                    price = plates * 4.49;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "temaki")
                {
                    price = plates * 5.19;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
            }
            else if (restaurant == "Sushi Bar")
            {
                if (type == "sashimi")
                {
                    price = plates * 5.25;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "maki")
                {
                    price = plates * 5.55;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "uramaki")
                {
                    price = plates * 6.25;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "temaki")
                {
                    price = plates * 4.75;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
            }
            else if (restaurant == "Asian Pub")
            {
                if (type == "sashimi")
                {
                    price = plates * 4.50;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "maki")
                {
                    price = plates * 4.80;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "uramaki")
                {
                    price = plates * 5.50;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
                else if (type == "temaki")
                {
                    price = plates * 5.50;
                    if (ch == 'Y')
                    {
                        delivery = (price * 20) / 100;
                        price += delivery;
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
            }
        }
    }
}
