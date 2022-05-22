using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(Request request, ICarService carService) : base(request)
        {
            this.carService = carService;
        }

        [Authorize]
        public Response Add()
        {
            if (carService.isMechanic(User.Id))
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = User.IsAuthenticated });
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddCarViewModel model)
        {
            var (isValid, errors) = carService.AddCar(model, User.Id);

            if (!isValid)
            {
                return View(new { IsAuthenticated = true, ErrorMessage = errors }, "/Error");
            }

            return Redirect("/");
        }

        [Authorize]
        public Response All()
        {
            //var model = new
            //{
            //    IsAuthenticated = User.IsAuthenticated,
            //    Year = 2010,
            //    Model = "Toyota",
            //    Img = "https://i.imgur.com/nhf5HgA.jpeg",
            //    CarPlate = "BP1111BP",
            //    RemIssues = 1,
            //    FixIssues = 2
            //};

            //var cars = carService.GetCars(User.Id);

            return View(new { IsAuthenticated = true, Cars = carService.GetCars(User.Id) });
        }
    }
}