using System;
using System.Collections.Generic;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap maps;

        public Controller()
        {
            
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            var message = string.Empty;

            if (type == "Pistol")
            {
                this.guns.Add(new Pistol(name, bulletsCount));
                message = $"Successfully added gun {nameof(Pistol)}.";
            }
            else if (type == "Rifle")
            {
                this.guns.Add(new Rifle(name, bulletsCount));
                message = $"Successfully added gun {nameof(Rifle)}.";
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            return message;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var message = string.Empty;

            if (type == "Terrorist")
            {
                if (gunName == "Pistol")
                {
                    message = $"Gun cannot be found!";

                    return message;
                }

                message = $"Successfully added player {username}.";

            }
            else if (type == "CounterTerrorist")
            {
                if (gunName == "Pistol")
                {
                    message = $"Gun cannot be found!";

                    return message;
                }

                message = $"Successfully added player {username}.";
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            return message;
        }

        public string StartGame()
        {
            throw new System.NotImplementedException();
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }
    }
}