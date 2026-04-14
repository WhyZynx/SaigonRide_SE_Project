using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Models;

namespace SaigonRideProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<OtpVerification> OtpVerifications { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.PricePerMinute)
                .HasPrecision(10, 2);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "System Admin",
                    Email = "admin@saigonride.com",
                    PasswordHash = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
                    UserType = "Local",
                    Role = "Admin",
                    IsVerified = true,
                    PassportStatus = "Approved"
                }
            );
        }
    }
}