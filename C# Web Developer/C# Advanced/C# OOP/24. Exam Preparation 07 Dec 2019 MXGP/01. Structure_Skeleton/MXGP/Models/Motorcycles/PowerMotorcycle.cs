using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsepower;

        private const double CubicCents = 450;
        private const int MinHP = 70;
        private const int MaxHP = 100;

        public PowerMotorcycle(string model, int horsepower) 
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