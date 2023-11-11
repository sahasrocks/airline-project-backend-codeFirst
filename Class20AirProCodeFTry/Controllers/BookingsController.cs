using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Class20AirProCodeFTry.Models;
using Class20AirProCodeFTry.BokRepo;

namespace Class20AirProCodeFTry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBokRepo _repository;
        public BookingsController(IBokRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _repository.GetBookings();

        }
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBookings(Booking booking)
        {
            return await _repository.PostBookings(booking);
        }
        [HttpPut]
        public async Task<ActionResult<Booking>> PutBookings(Booking booking)
        {
            return await _repository.PutBookings(booking);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBookings(int id)
        {
            try
            {
                return await _repository.DeleteBookings(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
