using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private int year;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year
        {
            get { return this.year; }

            set
            {
                if (this.year < 1989)
                {
                    throw new InvalidOperationException("Year cannot be less than 1989");
                }

                this.year = value;
            }
        }
    }
}
