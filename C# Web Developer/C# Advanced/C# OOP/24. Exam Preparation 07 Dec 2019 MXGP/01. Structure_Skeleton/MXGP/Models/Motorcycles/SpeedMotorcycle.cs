using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsepower;

        private const double CubicCents = 125;
        private const int MinHP = 50;
        private const int MaxHP = 69;


        public SpeedMotorcycle(string model, int horsepower) 
            : base(model, horsepower, CubicCents)
        {

        }

        public override int HorsePower
        {
            get => horsepower;

            protected set
            {
                if (value < MinHP || value > MaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsepower = value;
            }
        }
    }
}