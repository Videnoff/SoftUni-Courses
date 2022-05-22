using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        (bool registred, string error) RegisterUser(RegisterViewModel model);

        (bool logged, string userId) LoginUser(LoginViewModel model);
    }
}