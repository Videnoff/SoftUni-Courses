using System.ComponentModel.DataAnnotations;
using Andreys.Services;
using Andreys.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(input.Username) || input.Username.Length < 4 || input.Username.Length > 20)
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.View();
            }

            if (!new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.View();
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.View();
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.View();
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.View();
            }

            this.usersService.Create(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}