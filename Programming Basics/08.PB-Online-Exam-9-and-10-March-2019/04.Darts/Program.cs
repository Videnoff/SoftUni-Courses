using System;

namespace Darts
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int startPoints = 301;
            int neusp = 0;
            int usp = 0;
            string command = Console.ReadLine();

            while ((startPoints != 0) && (command != "Retire"))
            {
                int n = int.Parse(Console.ReadLine());

                if (command == "Single")
                {
                    if (startPoints >= n)
                    {
                        startPoints -= n;
                        usp++;
                    }
                    else
                    {
                        neusp++;
                    }
                }
                else if (command == "Double")
                {
                    if (startPoints >= (2 * n))
                    {
                        startPoints = startPoints - 2 * n;
                        usp++;
                    }
                    else
                    {
                        neusp++;
                    }
                }
                else if (command == "Triple")
                {
                    if (startPoints >= (3 * n))
                    {
                        startPoints = startPoints - 3 * n;
                        usp++;
                    }
                    else
                    {
                        neusp++;
                    }
                }
                else if (command == "Retire")
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Retire")
            {
                Console.WriteLine($"{name} retired after {neusp} unsuccessful shots.");
            }
            else if (startPoints == 0)
            {
                Console.WriteLine($"{name} won the leg with {usp} shots.");
            }
        }
    }
}
