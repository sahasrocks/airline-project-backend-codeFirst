using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class20AirProCodeFTry.FltRepo
{
    public class FltRepo : IFltRepo
    {
        private readonly airLineDbContext _context;
        public FltRepo(airLineDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<ActionResult<Flight>> PostFlights(Flight flight)
        {

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }
        public async Task<ActionResult<Flight>> PutFlights(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flight;
        }
        public async Task<ActionResult<Flight>> DeleteFlights(int id)
        {
            var regFlight = await _context.Flights.FindAsync(id);
            if (regFlight == null)
            {
                throw new NullReferenceException("Sorry no Flight found with this id");
            }
            else
            {
                _context.Flights.Remove(regFlight);
                await _context.SaveChangesAsync();
                return regFlight;
            }
        }

    }
}