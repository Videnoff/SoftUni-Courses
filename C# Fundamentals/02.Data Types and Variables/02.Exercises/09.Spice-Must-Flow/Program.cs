using System;

namespace SpiceMustFlow
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int spicesMined = 0;
            int days = 0;

            int dropdownYieldConstant = 10;
            int workersConsume = 26;

            while (startingYield >= 100)
            {
                spicesMined += startingYield;
                spicesMined -= workersConsume;
                startingYield -= dropdownYieldConstant;
                days++;
            }

            if (spicesMined != 0)
            {
                spicesMined -= workersConsume;
            }
            Console.WriteLine(days);
            Console.WriteLine(spicesMined);
        }
    }
}
