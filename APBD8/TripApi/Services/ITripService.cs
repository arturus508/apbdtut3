using System.Collections.Generic;
using System.Threading.Tasks;
using TripApi.Models;

namespace TripApi.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetTripsAsync();
        Task<Trip> GetTripByIdAsync(int id);
        Task AddTripAsync(Trip trip);
        Task UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(int id);
    }
}
