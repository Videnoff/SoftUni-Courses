using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            FillQueue(n, pumps);
            int cnt = 0;

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;

                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = pumps.Dequeue();
                    fuelAmount += currentPump[0];

                    if (fuelAmount < currentPump[1])
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= currentPump[1];
                    pumps.Enqueue(currentPump);
                }

                if (foundPoint)
                {
                    break;
                }

                cnt++;

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(cnt);
        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currPump = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currPump);
            }
        }
    }
}
