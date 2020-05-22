namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int UnitsOxygenDecrease = 5;
        private const double InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {

        }


        public override void Breath()
        {
            if (this.Oxygen - UnitsOxygenDecrease > 0)
            {
                this.Oxygen -= UnitsOxygenDecrease;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}