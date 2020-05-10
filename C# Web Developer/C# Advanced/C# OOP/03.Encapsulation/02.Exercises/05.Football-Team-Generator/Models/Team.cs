using System;
using System.Collections.Generic;
using System.Linq;
using _05.Football_Team_Generator.Common;

namespace _05.Football_Team_Generator.Models
{
    public class Team
    {
        private string name;

        private List<Player> players;

        public Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
        {
            this.Name = name;
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

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int) Math.Round(this.players.Sum(p => p.OverallSkill) / this.players.Count);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                string excMsg = string.Format(GlobalConstants.RemovingMissingPlayerExceptionMessage, name,
                    this.name);

                throw new InvalidOperationException(excMsg);
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}