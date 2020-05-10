namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        //public Battery Battery { get; set; }

        public int Battery { get; set; }

        public override string Start()
        {
            return "Tesla does not make any noise";
        }
    }
}