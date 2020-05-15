using System;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private bool canFire;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.TotalBullets > 0 || this.BulletsPerBarrel > 0;

        public abstract int Fire();

        protected void Reload(int barrelCapacity)
        {
            if (this.TotalBullets >= barrelCapacity)
            {
                this.BulletsPerBarrel = barrelCapacity;
                this.TotalBullets -= barrelCapacity;
            }
        }

        protected int DecreaseBullets(int bullets)
        {
            int firedBullets = 0;

            if (this.BulletsPerBarrel - bullets >= 0)
            {
                this.BulletsPerBarrel -= bullets;
                firedBullets = bullets;
            }

            return firedBullets;
        }
    }
}