using Microsoft.AspNetCore.Mvc;
using TripApi.Data;
using TripApi.Models;

namespace TripApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetTrip(int id)
        {
            var trip = _context.Trips.Find(id);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        [HttpPost]
        public IActionResult CreateTrip([FromBody] Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTrip), new { id = trip.IdTrip }, trip);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip trip)
        {
            var existingTrip = _context.Trips.Find(id);
            if (existingTrip == null)
            {
                return NotFound();
            }

            existingTrip.Name = trip.Name;
            existingTrip.Description = trip.Description;
            existingTrip.DateFrom = trip.DateFrom;
            existingTrip.DateTo = trip.DateTo;
            existingTrip.MaxPeople = trip.MaxPeople;

            _context.Trips.Update(existingTrip);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

