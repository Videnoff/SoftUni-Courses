using System;
using System.Globalization;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();

            return this.View(trips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel trip)
        {
            if (string.IsNullOrEmpty(trip.StartPoint))
            {
                return this.Error("Invalid Start Point");
            }

            if (string.IsNullOrEmpty(trip.EndPoint))
            {
                return this.Error("Invalid End Point");
            }

            if (!DateTime.TryParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Invalid Departure Time");
            }

            if (trip.Seats < 2 || trip.Seats > 6)
            {
                return this.Error("Invalid Seats");
            }

            if (string.IsNullOrEmpty(trip.Description) || trip.Description.Length > 80)
            {
                return this.Error("Description is required.");
            }

            this.tripsService.Create(trip);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetDetails(tripId);

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available.");
            }

            var userId = this.GetUserId();

            if (!this.tripsService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            return this.Redirect("/Trips/All");
        }
    }
}