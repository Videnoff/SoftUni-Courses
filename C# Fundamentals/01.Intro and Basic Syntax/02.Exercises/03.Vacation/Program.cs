using System;

namespace Vacation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0.0;
            double discount = 0.0;
            double sum = 0.0;
            double totalSum = 0.0;
            if (type == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                    sum = price * count;
                    if (count >= 30)
                    {
                        discount = (15 * sum) / 100;
                    }
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                    sum = price * count;
                    if (count >= 30)
                    {
                        discount = (15 * sum) / 100;
                    }
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                    sum = price * count;
                    if (count >= 30)
                    {
                        discount = (15 * sum) / 100;
                    }
                }
            }
            else if (type == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                    sum = price * count;
                    if (count >= 100)
                    {
                        discount = 10 * price;
                    }
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                    sum = price * count;
                    if (count >= 100)
                    {
                        discount = 10 * price;
                    }
                }
                else if (day == "Sunday")
                {
                    price = 16;
                    sum = price * count;
                    if (count >= 100)
                    {
                        discount = 10 * price;
                    }
                }
            }
            else if (type == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                    sum = price * count;
                    if (count >= 10 && count <= 20)
                    {
                        discount = (5 * sum) / 100;
                    }
                }
                else if (day == "Saturday")
                {
                    price = 20;
                    sum = price * count;
                    if (count >= 10 && count <= 20)
                    {
                        discount = (5 * sum) / 100;
                    }
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                    sum = price * count;
                    if (count >= 10 && count <= 20)
                    {
                        discount = (5 * sum) / 100;
                    }
                }
            }

            totalSum = sum - discount;
            Console.WriteLine($"Total price: {totalSum:F2}");
        }
    }
}
