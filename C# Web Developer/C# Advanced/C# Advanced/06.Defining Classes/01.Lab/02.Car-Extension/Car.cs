using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private int year;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year
        {
            get { return this.year; }

            set
            {
                if (this.year < 1989)
                {
                    throw new InvalidOperationException("Year cannot be less than 1989");
                }

                this.year = value;
            }
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; }

        public void Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;
            var canContinue = this.FuelQuantity - neededFuel >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                throw new InvalidOperationException("Not enough fuel");
            }
        }

        public string GetSpecifications()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity}");
            return sb.ToString();
        }
    }
}
