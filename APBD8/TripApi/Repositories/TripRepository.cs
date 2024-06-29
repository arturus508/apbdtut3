using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripApi.Data;
using TripApi.Models;

namespace TripApi.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext _context;

        public TripRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            return trip ?? throw new Exception("Trip not found");
        }


        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
