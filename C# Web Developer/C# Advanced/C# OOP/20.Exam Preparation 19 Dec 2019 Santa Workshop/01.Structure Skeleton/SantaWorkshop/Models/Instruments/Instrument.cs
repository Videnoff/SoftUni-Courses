﻿using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => power;

            private set
            {
                this.power = value > 0 ? value : 0;
            }
        }

        public void Use()
        {
            this.Power -= 10;
        }

        public bool IsBroken() => this.Power == 0;
    }
}