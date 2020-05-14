namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int PistolBulletsPerFire = 1;

        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            var firedBullets = this.BulletsCount - PistolBulletsPerFire;

            return firedBullets;
        }
    }
}