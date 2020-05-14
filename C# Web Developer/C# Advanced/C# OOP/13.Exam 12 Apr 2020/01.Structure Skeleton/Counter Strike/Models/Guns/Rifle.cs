namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleBulletsPerFire = 10;

        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            var firedBullets = this.BulletsCount - RifleBulletsPerFire;

            return firedBullets;
        }
    }
}