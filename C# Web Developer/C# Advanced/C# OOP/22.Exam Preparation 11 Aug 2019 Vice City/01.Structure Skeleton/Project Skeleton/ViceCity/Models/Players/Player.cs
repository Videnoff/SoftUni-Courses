using System;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private readonly IRepository<IGun> gunRepository;
        private readonly bool isAlive;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Player's name cannot be null or a whitespace!");
                }

                name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository => this.gunRepository;

        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Player life points cannot be below zero!");
                }

                lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this.lifePoints -= points;

            if (this.lifePoints < 0)
            {
                this.lifePoints = 0;
            }
        }
    }
}