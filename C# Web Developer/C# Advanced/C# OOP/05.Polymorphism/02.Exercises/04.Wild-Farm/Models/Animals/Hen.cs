using System;
using System.Collections.Generic;
using _04.Wild_Farm.Models.Foods;

namespace _04.Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_MULTUPLIER = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => WEIGHT_MULTUPLIER;

        public override ICollection<Type> PreferredFoods => new List<Type>() {typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}