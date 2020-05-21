using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        private Pilot()
        {
            this.machines = new List<IMachine>();
        }

        public Pilot(string name) 
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public IList<IMachine> Machines => this.machines;

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException($"Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}