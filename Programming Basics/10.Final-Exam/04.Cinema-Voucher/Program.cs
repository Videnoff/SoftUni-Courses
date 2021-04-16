using System;

namespace CinemaVoucher
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int movie = 0;
            int other = 0;

            while (command != "End" && n != 0)
            {
                int price = 0;

                if (command.Length > 8)
                {
                    char curr = command[0];
                    char curr2 = command[1];
                    price = curr + curr2;
                    if (n >= price)
                    {
                        n = (n - price);
                        movie++;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (command.Length <= 8)
                {
                    char curr3 = command[0];
                    price += curr3;
                    if (n >= price)
                    {
                        n = (n - price);
                        other++;
                    }
                    else
                    {
                        break;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{movie}");
            Console.WriteLine($"{other}");
        }
    }
}
