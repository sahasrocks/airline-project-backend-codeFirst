using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Class20AirProCodeFTry.Models;
using Class20AirProCodeFTry.BokRepo;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBookings(Booking booking)
        {
            try
            {
                /*var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var token = HttpContext.Request.Headers["Authorization"];*/
                

                // Log or debug userId to check if it's correctly extracted from the token.

                return await _repository.PostBookings(booking);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation.
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Booking>> PutBookings(Booking booking)
        {
            return await _repository.PutBookings(booking);
        }
        /*[HttpGet]
        public async  Task<ActionResult<IEnumerable<Booking>>> GetBookingsByUserId(string userId)
        {
            return await _repository.GetBookingsByUserId(userId);
        }*/
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
