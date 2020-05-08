using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].Name == name)
                {
                    gladiators.RemoveAt(i);
                }
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator highestStat = gladiators[0];

            foreach (var gladiator in gladiators)
            {
                if (gladiator.GetStatPower() > highestStat.GetStatPower())
                {
                    highestStat = gladiator;
                }
            }

            return highestStat;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator highestWeapon = gladiators[0];

            foreach (var gladiator in gladiators)
            {
                if (gladiator.GetWeaponPower() > highestWeapon.GetWeaponPower())
                {
                    highestWeapon = gladiator;
                }
            }

            return highestWeapon;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator highestTotal = gladiators[0];

            foreach (var gladiator in gladiators)
            {
                if (gladiator.GetTotalPower() > highestTotal.GetTotalPower())
                {
                    highestTotal = gladiator;
                }
            }

            return highestTotal;
        }

        public override string ToString()
        {
            return $"{this.Name} - {gladiators.Count} gladiators are participating.";
        }
    }
}
