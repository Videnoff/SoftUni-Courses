using System;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly IList<IPlanet> planets;

        private string name;

        private Planet()
        {
            this.planets = new List<IPlanet>();
        }

        public Planet(string name) 
            : this()
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), $"Invalid name!");
                }

                this.name = value;
            }
        }
    }
}