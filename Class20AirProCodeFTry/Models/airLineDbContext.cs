using Microsoft.EntityFrameworkCore;

namespace Class20AirProCodeFTry.Models
{
    public class airLineDbContext : DbContext
    {
        public airLineDbContext(DbContextOptions<airLineDbContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
