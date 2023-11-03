using Microsoft.EntityFrameworkCore;
using SRC_Travel.Models;

namespace SRC_Travel.Data
{
    public class DbConnection:DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Buses> Buses { get; set; }
        public DbSet<BusRoutes> BusRoutes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RouteDetails> RouteDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCounter> TicketCounters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SRC_Travel.Models.BusType>? BusType { get; set; }
    }
}
