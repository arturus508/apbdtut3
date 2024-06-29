using System.Collections.Generic;
using System.Threading.Tasks;
using TripApi.Models;
using TripApi.Repositories;

namespace TripApi.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync()
        {
            return await _tripRepository.GetTripsAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            return await _tripRepository.GetTripByIdAsync(id);
        }

        public async Task AddTripAsync(Trip trip)
        {
            await _tripRepository.AddTripAsync(trip);
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            await _tripRepository.UpdateTripAsync(trip);
        }

        public async Task DeleteTripAsync(int id)
        {
            await _tripRepository.DeleteTripAsync(id);
        }
    }
}
