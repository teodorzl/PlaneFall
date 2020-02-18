namespace Planefall.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PlanefallDbContext : IdentityDbContext<PlanefallUser>
    {
        public PlanefallDbContext(DbContextOptions<PlanefallDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}