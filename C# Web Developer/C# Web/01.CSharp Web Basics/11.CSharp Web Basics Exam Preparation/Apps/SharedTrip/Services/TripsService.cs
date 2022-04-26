using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.dbContext.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count
                })
                .ToList();

            return trips;
        }

        public void Create(AddTripViewModel trip)
        {
            var dbTrip = new Trip
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = trip.ImagePath,
                Seats = trip.Seats,
                Description = trip.Description
            };

            this.dbContext.Trips.Add(dbTrip);
            this.dbContext.SaveChanges();
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.dbContext.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count,
                    Description = x.Description
                })
                .FirstOrDefault();

            return trip;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.dbContext.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new
                {
                    x.Seats,
                    TakenSeats = x.UserTrips.Count
                })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.dbContext.UserTrips
                .Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            this.dbContext.UserTrips.Add(userTrip);
            this.dbContext.SaveChanges();

            return true;
        }
    }
}