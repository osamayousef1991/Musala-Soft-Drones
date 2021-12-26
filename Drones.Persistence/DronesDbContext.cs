using Drones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Persistence
{
    public interface IDronesDbContext
    {
    }

    public class DronesDbContext : DbContext, IDronesDbContext
    {
        public DronesDbContext(DbContextOptions<DronesDbContext> options) : base(options)
        {
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<DroneLoad> DroneLoads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}