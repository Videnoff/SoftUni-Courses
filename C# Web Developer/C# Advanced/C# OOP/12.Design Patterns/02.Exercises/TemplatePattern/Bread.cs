﻿using System;

namespace TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        /*
         * Template method -> For any type of bread is valid
         */
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}