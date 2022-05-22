using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;

        public IssuesController(Request request, IIssueService issueService) : base(request)
        {
            this.issueService = issueService;
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            //var model1 = new
            //{
            //    IsAuthenticated = User.IsAuthenticated,
            //    Year = 2010,
            //    Model = "Fuck"
            //};

            var model = issueService.GetIssues(carId);
            var model2 = issueService.GetIssues2(carId);

            return View(new { model.Year, model.IsAuthenticated, model.Model, model.CarId, model2 });
        }

        [Authorize]
        public Response Add(string carId)
        {
            return View(new { IsAuthenticated = User.IsAuthenticated, CarId = carId });
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddIssuesViewModel model)
        {
            var (isValid, errors) = issueService.AddIssue(model);

            if (!isValid)
            {
                return View(new { IsAuthenticated = true, ErrorMessage = errors }, "/Error");
            }

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public Response Fix(string issueId, string carId)
        {
            issueService.FixIssue(issueId, User.Id);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public Response Delete(string issueId, string carId)
        {
            issueService.DeleteIssue(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}