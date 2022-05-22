using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService) : base(request)
        {
            this.userService = userService;
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/"); //Cars/All
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            var (isValid, userId) = userService.LoginUser(model);

            if (!isValid)
            {
                return View(new { IsAuthenticated = false, ErrorMessage = "Login incorrect" }, "/Error");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/"); //Cars/All
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, error) = userService.RegisterUser(model);

            if (!isValid)
            {
                return View(new { IsAuthenticated = false, ErrorMessage = error }, "/Error");
            }

            return Redirect("/Users/Login");
        }
    }
}