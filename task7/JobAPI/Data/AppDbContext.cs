using Microsoft.EntityFrameworkCore;
namespace JobAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobListing>().ToTable("Jobs");
        }
        public DbSet<JobListing>? JobListings;
    }
}