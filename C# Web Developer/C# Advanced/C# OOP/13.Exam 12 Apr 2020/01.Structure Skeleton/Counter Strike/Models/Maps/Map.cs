using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.counterTerrorists = new List<IPlayer>();
            this.terrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            var message = string.Empty;

            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else
                {
                    counterTerrorists.Add(player);
                }
            }

            foreach (var terrorist in terrorists)
            {
                while (terrorist.IsAlive)
                {
                    terrorist.Gun.Fire();
                }


            }

            if (terrorists.Any())
            {
                message = $"Terrorist wins!";
            }
            else
            {
                message = $"Counter Terrorist wins!";
            }

            return message;
        }
    }
}