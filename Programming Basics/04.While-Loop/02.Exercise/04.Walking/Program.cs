using System;

namespace Walking
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int steps = 0;
            int diff = 0;
            while (steps < 10000)
            {
                string s = Console.ReadLine();

                if (s == "Going home")
                {
                    steps += int.Parse(Console.ReadLine());
                    if (steps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                    else
                    {

                        diff = 10000 - steps;
                        Console.WriteLine($"{diff} more steps to reach goal.");
                    }
                    break;
                }
                else
                {
                    steps += int.Parse(s);
                    if (steps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                }
            }
        }
    }
}
