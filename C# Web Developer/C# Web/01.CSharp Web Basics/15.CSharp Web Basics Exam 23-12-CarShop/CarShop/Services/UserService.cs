using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public (bool logged, string userId) LoginUser(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(w => w.Username == model.Username)
                .Where(w => w.Password == HashPassword(model.Password))
                .SingleOrDefault();

            if (user == null)
            {
                return (false, String.Empty);
            }

            return (true, user.Id);
        }

        public (bool registred, string error) RegisterUser(RegisterViewModel model)
        {
            bool registred = false;
            bool existUsername = repo.All<User>().Any(a => a.Username == model.Username);

            if (existUsername)
            {
                return (registred, "Registration failed");
            }

            bool existEmail = repo.All<User>().Any(a => a.Email == model.Email);

            if (existEmail)
            {
                return (registred, "Registration failed");
            }

            (bool isValid, string error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            var user = new User { Username = model.Username, Email = model.Email, Password = HashPassword(model.Password), IsMechanic = model.UserType == "Mechanic" ? true : false };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registred = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registred, error);
        }

        private string HashPassword(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}