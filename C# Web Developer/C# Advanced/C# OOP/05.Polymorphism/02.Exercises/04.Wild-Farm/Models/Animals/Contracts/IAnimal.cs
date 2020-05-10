using _04.Wild_Farm.Models.Foods.Contracts;

namespace _04.Wild_Farm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        
        double Weight { get; }
        
        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);
    }
}