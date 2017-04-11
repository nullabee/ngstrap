using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Nuance> Nuances { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nuance>().ToTable("Nuances");
            modelBuilder.Entity<Waypoint>().ToTable("Waypoints");
        }
    }
}
