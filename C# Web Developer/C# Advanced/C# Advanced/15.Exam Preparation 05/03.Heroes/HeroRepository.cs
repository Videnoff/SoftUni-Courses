using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            data = data.Where(x => x.Name != name).Select(y => y).ToList();
        }

        public Hero GetHeroWithHighestStrength()
        {
            var highestStrength = this.data.OrderByDescending(x => x.Item.Strength).First();

            return highestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var highestAbility = this.data.OrderByDescending(x => x.Item.Ability).First();

            return highestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var highestIntelligence = this.data.OrderByDescending(x => x.Item.Ability).First();

            return highestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.data.Count >= 0)
            {
                foreach (var hero in data)
                {
                    sb.AppendLine($"{hero}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
