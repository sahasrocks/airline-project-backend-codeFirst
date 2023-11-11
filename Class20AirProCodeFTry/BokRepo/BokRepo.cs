using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class20AirProCodeFTry.BokRepo
{
    public class BokRepo : IBokRepo
    {
        private readonly airLineDbContext _context;
        public BokRepo(airLineDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                .Include(c => c.User)
                .Include(c => c.Flight)
                .ToListAsync();
        }

        public async Task<ActionResult<Booking>> PostBookings(Booking booking)
        {
            var userid = await _context.Users.FindAsync(booking.UserId);
            var flightid = await _context.Flights.FindAsync(booking.FlightId);
            
            booking.User = userid;
            booking.Flight = flightid;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<ActionResult<Booking>> PutBookings(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<ActionResult<Booking>> DeleteBookings(int id)
        {
            var regBooking = await _context.Bookings.FindAsync(id);
            if (regBooking == null)
            {
                throw new NullReferenceException("Sorry no Booking found with this id");
            }
            else
            {
                _context.Bookings.Remove(regBooking);
                await _context.SaveChangesAsync();
                return regBooking;
            }
        }

    }
}
