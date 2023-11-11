using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Class20AirProCodeFTry.Models;
using Class20AirProCodeFTry.UsrRepo;

namespace Class20AirProCodeFTry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsrRepo _repository;
        public UsersController(IUsrRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _repository.GetUsers();

        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            return await _repository.PostUsers(user);
        }
        [HttpPut]
        public async Task<ActionResult<User>> PutUsers(User user)
        {
            return await _repository.PutUsers(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsers(string id)
        {
            try
            {
                return await _repository.DeleteUsers(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

