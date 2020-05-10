using System;
using System.Collections;
using System.Collections.Generic;
using _04.Wild_Farm.Exceptions;
using _04.Wild_Farm.Models.Animals.Contracts;
using _04.Wild_Farm.Models.Foods.Contracts;

namespace _04.Wild_Farm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableFoodMessage = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        /*
         * Abstract because they are different for every type of animal
         */
        public abstract double WeightMultiplier { get; }


        /*
         * List of all foods that are being eaten by this animal
         */
        public abstract ICollection<Type> PreferredFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new UneatableFoodException(string.Format(UneatableFoodMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}