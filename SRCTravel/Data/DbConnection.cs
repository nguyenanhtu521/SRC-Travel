using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SRCTravel.Models;

namespace SRCTravel.Data
{
    public class DbConnection : IdentityDbContext<User>
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }

        protected DbConnection()
        {
        }

        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Buses> Buses { get; set; }
        public DbSet<BusRoutes> BusRoutes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RouteDetails> RouteDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCounter> TicketCounters { get; set; }
        
        public DbSet<BusType>? BusType { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
