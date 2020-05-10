using System;
using _05.Football_Team_Generator.Common;

namespace _05.Football_Team_Generator.Models
{
    public class Stats
    {
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;

        private const double STATS_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            set
            {
                this.ValidateStat(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            set
            {
                this.ValidateStat(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.sprint));

                this.sprint = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.shooting));

                this.shooting = value;
            }
        }

        public double AverageStats => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STATS_COUNT;

        private void ValidateStat(int value, string statName)
        {
            if (value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                string excMsg = String.Format(GlobalConstants.InvalidStatExceptionMessage, statName);

                throw new ArgumentException(excMsg);
            }
        }
    }
}