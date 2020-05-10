using System;
using _05.Football_Team_Generator.Common;

namespace _05.Football_Team_Generator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
                }
            }
        }

        public Stats Stats { get; private set; }

        public double OverallSkill => this.Stats.AverageStats;
    }
}