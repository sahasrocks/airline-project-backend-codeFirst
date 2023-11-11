using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class20AirProCodeFTry.UsrRepo
{
    public class UsrRepo : IUsrRepo
    {
        private readonly airLineDbContext _context;

        public UsrRepo(airLineDbContext context)
        {
            _context = context;
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
    }
}
