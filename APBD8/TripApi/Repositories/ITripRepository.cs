using System.Collections.Generic;
using System.Threading.Tasks;
using TripApi.Models;

namespace TripApi.Repositories
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetTripsAsync();
        Task<Trip> GetTripByIdAsync(int id);
        Task AddTripAsync(Trip trip);
        Task UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(int id);
    }
}
