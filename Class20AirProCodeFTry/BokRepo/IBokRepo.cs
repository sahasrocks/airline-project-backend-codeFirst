using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class20AirProCodeFTry.BokRepo
{
    public interface IBokRepo
    {
        Task<ActionResult<IEnumerable<Booking>>> GetBookings();
        Task<ActionResult<Booking>> PostBookings(Booking booking);
        Task<ActionResult<Booking>> PutBookings(Booking booking);
        Task<ActionResult<Booking>> DeleteBookings(int id);
        //Task<ActionResult<IEnumerable<Booking>>> GetBookingsByUserId(string userId);
    }
}
