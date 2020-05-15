using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new Collection<IPlayer>();
            this.guns = new Collection<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle) == type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return $"Invalid gun type!";
            }

            this.guns.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return $"There are no guns in the queue!";
            }

            var gun = this.guns.FirstOrDefault();
            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            string message = string.Empty;

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
            }
            else
            {
                return $"Civil player with that name doesn't exists!";
            }

            this.guns.Remove(gun);
            return message;
        }

        public string Fight()
        {
            var mainPlayerLifePoints = this.mainPlayer.LifePoints;
            var totalSumLifePoints = this.civilPlayers.Sum(p => p.LifePoints);
            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            var mainPlayerLifePointsAfterFight = this.mainPlayer.LifePoints;
            var totalSumLifePointsAfterFight = this.civilPlayers.Sum(p => p.LifePoints);
            var aliveCivilPlayersCount = this.civilPlayers.Count(p => p.IsAlive);

            var message = string.Empty;

            // TODO
            if (mainPlayerLifePoints == mainPlayerLifePointsAfterFight && totalSumLifePoints == aliveCivilPlayersCount)
            {
                message = $"Everything is okay!";
            }
            else
            {
                message = $"A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine;
                message += $"Tommy has killed: {this.civilPlayers.Count - aliveCivilPlayersCount} players!" +
                           Environment.NewLine;
                message += $"Left Civil Players: {aliveCivilPlayersCount}!";
            }

            return message;
        }
    }
}