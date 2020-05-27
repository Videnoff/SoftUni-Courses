using System;

namespace GamingStore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            double outFall4Price = 39.99;
            double csogPrice = 15.99;
            double zplinterZellPrice = 19.99;
            double honored2Price = 59.99;
            double roverWatchPrice = 29.99;
            double roverWatchOriginsEditionPrice = 39.99;
            double totalSum = 0.0;

            string command = Console.ReadLine();

            while (command != "Game Time")
            {
                if (balance > 0)
                {
                    switch (command)
                    {
                        case "OutFall 4":
                            if (balance < outFall4Price)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= outFall4Price;
                                totalSum += outFall4Price;
                            }
                            break;
                        case "CS: OG":
                            if (balance < csogPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= csogPrice;
                                totalSum += csogPrice;
                            }
                            break;
                        case "Zplinter Zell":
                            if (balance < zplinterZellPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= zplinterZellPrice;
                                totalSum += zplinterZellPrice;
                            }
                            break;
                        case "Honored 2":
                            if (balance < honored2Price)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= honored2Price;
                                totalSum += honored2Price;
                            }
                            break;
                        case "RoverWatch":
                            if (balance < roverWatchPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= roverWatchPrice;
                                totalSum += roverWatchPrice;
                            }
                            break;
                        case "RoverWatch Origins Edition":
                            if (balance < roverWatchOriginsEditionPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {command}");
                                balance -= roverWatchOriginsEditionPrice;
                                totalSum += roverWatchOriginsEditionPrice;
                            }
                            break;
                        default:
                            Console.WriteLine("Not Found");
                            break;
                    }
                }
                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalSum:F2}. Remaining: ${balance:F2}");
        }
    }
}
