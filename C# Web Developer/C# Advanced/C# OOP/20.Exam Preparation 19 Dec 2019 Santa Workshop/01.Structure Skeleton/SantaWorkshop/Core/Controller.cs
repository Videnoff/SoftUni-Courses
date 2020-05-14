using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;

        private const int DwarfMinEnergy = 50;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }


            IInstrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName, energyRequired);
        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();
            IPresent present = this.presents.FindByName(presentName);

            ICollection<IDwarf> dwarves = this.dwarfs.Models
                .Where(d => d.Energy >= DwarfMinEnergy)
                .OrderByDescending(dw => dw.Energy)
                .ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            while (dwarves.Any())
            {
                IDwarf currDwarf = dwarves.First();

                workshop.Craft(present, currDwarf);

                if (!currDwarf.Instruments.Any())
                {
                    dwarves.Remove(currDwarf);
                }

                if (currDwarf.Energy == 0)
                {
                    dwarves.Remove(currDwarf);
                    this.dwarfs.Remove(currDwarf);
                }

                if (present.IsDone())
                {
                    break;
                }
            }

            return string.Format(present.IsDone() ? OutputMessages.PresentIsDone : OutputMessages.PresentIsNotDone, presentName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var countCraftedPresents = this.presents.Models.Count(p => p.IsDone());

            sb.AppendLine($"{countCraftedPresents} presents are done!");

            sb.AppendLine($"Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                var countInstruments = dwarf.Instruments
                    .Count(i => !i.IsBroken());

                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}