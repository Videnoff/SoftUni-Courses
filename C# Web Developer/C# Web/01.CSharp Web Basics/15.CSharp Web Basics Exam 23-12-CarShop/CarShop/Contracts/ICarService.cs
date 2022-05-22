using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        (bool added, string error) AddCar(AddCarViewModel model, string userId);

        IEnumerable<AllCarsViewModel> GetCars(string userId);

        bool isMechanic(string userId);
    }
}