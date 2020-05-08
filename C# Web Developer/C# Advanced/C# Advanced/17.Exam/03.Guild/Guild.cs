using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {

        List<Player> roster;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public int Count => this.roster.Count;

        public Guild()
        {
            this.roster = new List<Player>();
        }

        public Guild(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (roster.Capacity + 1 >= roster.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(r => r.Name == name);

            if (player != null)
            {
                this.roster.Remove(player);

                return true;
            }

            return false;
        }

        public Player PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }

            return player;
        }

        public Player DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Member";
            }

            return player;
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = this.roster.Where(p => p.Class == @class).ToArray();

            foreach (var player in players)
            {
                this.roster.Remove(player);
            }

            return players;
        }
    }
}
