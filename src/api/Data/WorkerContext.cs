using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Worker");
        }
    }
}
