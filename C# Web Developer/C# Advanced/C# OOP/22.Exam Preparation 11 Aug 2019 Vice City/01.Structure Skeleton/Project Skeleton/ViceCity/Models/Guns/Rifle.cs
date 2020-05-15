namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsPerFire = 5;

        public Rifle(string name) 
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