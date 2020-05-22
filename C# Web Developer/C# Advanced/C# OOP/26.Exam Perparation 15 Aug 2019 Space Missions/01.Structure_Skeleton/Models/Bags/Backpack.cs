using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private ICollection<string> backpack;

        public Backpack()
        {
            this.backpack = new List<string>();
        }

        public ICollection<string> Items
        {
            get => backpack;

            protected set
            {
                this.backpack = value;
            }
        }
    }
}