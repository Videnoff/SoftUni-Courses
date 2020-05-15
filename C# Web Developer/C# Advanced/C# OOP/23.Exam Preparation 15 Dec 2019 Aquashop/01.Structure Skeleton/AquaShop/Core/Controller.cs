using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            var result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            var result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decoration == null)
            {
                var exceptionMessage = string.Format(ExceptionMessages.InexistentDecoration, decorationType);

                throw new InvalidOperationException(exceptionMessage);
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            var result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

            return result;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            // TODO: Refactor this

            if (fish.GetType() == typeof(FreshwaterFish) && aquarium.GetType() == typeof(SaltwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }

            if (fish.GetType() == typeof(SaltwaterFish) && aquarium.GetType() == typeof(FreshwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            var message = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            return message;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            var result = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);

            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var totalPrice = aquarium.Fish.Sum(p => p.Price) + aquarium.Decorations.Sum(p => p.Price);

            var result = string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}