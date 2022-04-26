using System.Collections.Generic;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<TripViewModel> GetAll();

        void Create(AddTripViewModel trip);

        TripDetailsViewModel GetDetails(string id);

        bool HasAvailableSeats(string tripId);

        bool AddUserToTrip(string userId, string tripId);
    }
}