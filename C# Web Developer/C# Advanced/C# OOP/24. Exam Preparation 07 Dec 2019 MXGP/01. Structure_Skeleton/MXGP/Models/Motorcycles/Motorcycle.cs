using System;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsepower;

        protected Motorcycle(string model, int horsepower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsepower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }


        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var racePoints = this.CubicCentimeters / this.HorsePower * laps;

            return racePoints;
        }
    }
}