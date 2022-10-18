using Microsoft.EntityFrameworkCore;
using SWP391_HealthCareProject.Models.Entity;

namespace SWP391_HealthCareProject.Data
{
    public class SWP391_HealthCareProjectDbContext : DbContext
    {
        

        public DbSet<User> Users { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Campain> Campains { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Hospital_RedCross> HospitalRedCrosses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
            modelBuilder.Entity<Campain>().ToTable("Campain");
            modelBuilder.Entity<Representative>().ToTable("Representative");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Hospital_RedCross>().ToTable("Hospital_RedCross");
        }
    }
}
