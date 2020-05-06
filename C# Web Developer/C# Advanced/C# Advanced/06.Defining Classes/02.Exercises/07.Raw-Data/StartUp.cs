using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Car> cars = new HashSet<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split()
                    .ToArray();

                string model = carArgs[0];

                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);

                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                double tire1Pressure = double.Parse(carArgs[5]);
                int tire1Age = int.Parse(carArgs[6]);

                double tire2Pressure = double.Parse(carArgs[7]);
                int tire2Age = int.Parse(carArgs[8]);

                double tire3Pressure = double.Parse(carArgs[9]);
                int tire3Age = int.Parse(carArgs[10]);

                double tire4Pressure = double.Parse(carArgs[11]);
                int tire4Age = int.Parse(carArgs[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);

            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                HashSet<Car> result = cars.Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1))
                    .ToHashSet();
            }
            else if (command == "flamable")
            {
                HashSet<Car> result = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToHashSet();

                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }
    }
}
