namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsPerFire = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < BulletsPerFire)
            {
                this.Reload(InitialBulletsPerBarrel);
            }

            int firedBullets = this.DecreaseBullets(BulletsPerFire);

            return firedBullets;
        }
    }
}