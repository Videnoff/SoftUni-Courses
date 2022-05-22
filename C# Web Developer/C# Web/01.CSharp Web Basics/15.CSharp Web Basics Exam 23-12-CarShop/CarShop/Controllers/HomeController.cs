using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Cars/All");
            }

            return View(new { IsAuthenticated = User.IsAuthenticated });
        }
    }
}