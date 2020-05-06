using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var cars = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input.Split(", ");
                var direction = splittedInput[0];
                var carNumber = splittedInput[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car}");
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
