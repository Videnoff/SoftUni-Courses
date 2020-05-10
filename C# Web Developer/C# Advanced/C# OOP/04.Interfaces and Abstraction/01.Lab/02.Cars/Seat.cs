namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
        : base(model, color)
        {

        }

        public override string Start()
        {
            return "Started";
        }
    }
}