using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        private Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public Aquarium(string name, int capacity) : 
            this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(c => c.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fish.AsReadOnly();

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name})");
            sb.AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(f => f.Name)) : "none")}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}