using System;

namespace PokeMon
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int originalPowerValue = power;
            int pokedTargets = 0;

            while (power >= distance)
            {
                power -= distance;
                pokedTargets++;

                if (power == originalPowerValue * 0.5 && exhaustionFactor != 0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(pokedTargets);
        }
    }
}
