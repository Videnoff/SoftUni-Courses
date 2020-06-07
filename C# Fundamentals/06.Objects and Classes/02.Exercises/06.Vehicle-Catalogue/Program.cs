using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            string[] data = new string[4];

            while (true)
            {
                data = Console.ReadLine().Split().ToArray();

                if (data[0] == "End")
                {
                    break;
                }

                string type = data[0];
                string model = data[1];
                string color = data[2];
                int horsePower = int.Parse(data[3]);

                if (data[0].ToLower() == "car")
                {
                    Car car = new Car();
                    {
                        car.Type = type;
                        car.Model = model;
                        car.Color = color;
                        car.HorsePower = horsePower;
                    }
                    cars.Add(car);
                }

                else if (data[0].ToLower() == "truck")
                {
                    Truck truck = new Truck()
                    {
                        Type = type,
                        Model = model,
                        Color = color,
                        HorsePower = horsePower
                    };
                    trucks.Add(truck);
                }
            }

            while (true)
            {
                string newModels = Console.ReadLine();

                if (newModels == "Close the Catalogue")
                {
                    break;
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model.Contains(newModels))
                    {
                        Console.WriteLine($"Type: Car");
                        Console.WriteLine($"Model: {cars[i].Model}");
                        Console.WriteLine($"Color: {cars[i].Color}");
                        Console.WriteLine($"Horsepower: {cars[i].HorsePower}");
                    }
                }

                for (int i = 0; i < trucks.Count; i++)
                {
                    if (trucks[i].Model.Contains(newModels))
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {trucks[i].Model}");
                        Console.WriteLine($"Color: {trucks[i].Color}");
                        Console.WriteLine($"Horsepower: {trucks[i].HorsePower}");
                    }
                }
            }

            int carsCount = 0;
            int trucksCount = 0;
            double carsHorsePower = 0.0;
            double truckshorserPower = 0.0;

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Type == "car")
                {
                    carsCount++;
                    carsHorsePower += cars[i].HorsePower;
                }
            }

            for (int i = 0; i < trucks.Count; i++)
            {
                if (trucks[i].Type == "truck")
                {
                    trucksCount++;
                    truckshorserPower += trucks[i].HorsePower;
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {((double)cars.Sum(x => x.HorsePower) / cars.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {((double)trucks.Sum(x => x.HorsePower) / trucks.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }

    public class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    public class Truck
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
