using System;

namespace Bus
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startPassengers = int.Parse(Console.ReadLine());
            int busStop = int.Parse(Console.ReadLine());
            int conductors = 2;
            int stopsCount = 1;
            for (int i = 0; i < busStop; i++)
            {
                int downPass = int.Parse(Console.ReadLine());
                int upPass = int.Parse(Console.ReadLine());

                if (stopsCount % 2 == 0)
                {
                    stopsCount++;
                    startPassengers -= downPass;
                    startPassengers += upPass;
                    startPassengers -= conductors;
                }
                else
                {
                    stopsCount++;
                    startPassengers -= downPass;
                    startPassengers += upPass;
                    startPassengers += conductors;
                }
            }
            Console.WriteLine($"The final number of passengers is : {startPassengers}");
        }
    }
}
