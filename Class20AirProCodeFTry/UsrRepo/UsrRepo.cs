using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Class20AirProCodeFTry.UsrRepo
{
    public class UsrRepo : IUsrRepo
    {
        private readonly airLineDbContext _context;
        private readonly IConfiguration _configuration;
        public UsrRepo(airLineDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> PostUsers(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<ActionResult<User>> PutUsers(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<ActionResult<User>> DeleteUsers(string id)
        {
            var regUser = await _context.Users.FindAsync(id);
            if (regUser == null)
            {
                throw new NullReferenceException("Sorry no user found with this id");
            }
            else
            {
                _context.Users.Remove(regUser);
                await _context.SaveChangesAsync();
                return regUser;
            }
        }
        /*public async Task<ActionResult<User>> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new BadRequestObjectResult("Username and password are required.");
            }
            var user1 = await _context.Users.FirstOrDefaultAsync(u => u.username == username && u.Password == password);
            if (user1 == null)
            {
                return new NotFoundObjectResult("Incorrect username or password.");
            
        }
            //return user1;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user1.username),
            new Claim(ClaimTypes.Role, user1.Role),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new JsonResult(new { Token = tokenString, Role = user1.Role }) { StatusCode = 200 };
        }*/
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new BadRequestObjectResult("Username and password are required.");
            }

            var user1 = await _context.Users.FirstOrDefaultAsync(u => u.username == username && u.Password == password);
            if (user1 == null)
            {
                return new NotFoundObjectResult("Incorrect username or password.");
            }

            if (string.IsNullOrEmpty(user1.username) || string.IsNullOrEmpty(user1.Password))
            {
                return new BadRequestObjectResult("User data is invalid.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user1.username),
            new Claim(ClaimTypes.Role, user1.Role),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new JsonResult(new { Token = tokenString, Role = user1.Role }) { StatusCode = 200 };
        }

        public async Task<ActionResult<User>> CheckAdminLogin(string username, string password)
        {
            var user1 = await _context.Users.FirstOrDefaultAsync(u => u.username == username && u.Password == password && u.Role == "admin");
            if (user1 == null)
            {
                // Return an error message or handle the case where the user doesn't exist or doesn't have the "admin" role.
                return new NotFoundObjectResult("Incorrect username, password, or not an admin user.");
            }
            return user1;
            

        }
    }
}
