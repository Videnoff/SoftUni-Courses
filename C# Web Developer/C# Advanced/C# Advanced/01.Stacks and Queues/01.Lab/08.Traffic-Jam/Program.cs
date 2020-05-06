using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passingCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "green")
                {
                    for (int i = 0; i < passingCars; i++)
                    {
                        if (cars.Any())
                        {
                            totalCarsPassed++;

                            string currentCar = cars.Dequeue();
                            Console.WriteLine($"{currentCar} passed!");
                        }
                    }
                }
                else if (command == "end")
                {
                    break;
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
