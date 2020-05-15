namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int SaltwaterAquariumCapacity = 50;


        public SaltwaterAquarium(string name) 
            : base(name, SaltwaterAquariumCapacity)
        {

        }
    }
}