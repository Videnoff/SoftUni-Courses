using System;
using System.Collections.Generic;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;


        private Dwarf()
        {
            this.Instruments = new List<IInstrument>();
        }

        protected Dwarf(string name, int energy) 
            : this()
        {
            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => energy;

            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments { get; }

        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }
    }
}