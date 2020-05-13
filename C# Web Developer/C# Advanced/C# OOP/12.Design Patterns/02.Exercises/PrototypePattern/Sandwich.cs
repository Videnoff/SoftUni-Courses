using System;

namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        /*
         * Prototype pattern
         */
        public override SandwichPrototype Clone()
        {
            /*
             * Output
             */
            var ingredientsString = this.GetIngredientsList();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientsString}");

            return this.MemberwiseClone() as SandwichPrototype;
        }

        /*
         * Only for output purposes
         */
        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}