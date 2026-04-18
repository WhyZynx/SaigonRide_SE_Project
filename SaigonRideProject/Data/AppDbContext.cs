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

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.PricePerMinute)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rental>()
                .Property(r => r.TotalFare)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Station)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.StationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Vehicle)
                .WithMany()
                .HasForeignKey(r => r.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.PickupStation)
                .WithMany()
                .HasForeignKey(r => r.PickupStationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.ReturnStation)
                .WithMany()
                .HasForeignKey(r => r.ReturnStationId)
                .OnDelete(DeleteBehavior.NoAction);

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
            modelBuilder.Entity<Station>().HasData(
                 new Station
                 {
                     Id = 1,
                     Name = "District 1 Station",
                     Capacity = 20,
                     CurrentInventory = 10
                 },
                 new Station
                 {
                     Id = 2,
                     Name = "District 3 Station",
                     Capacity = 15,
                     CurrentInventory = 5
                 }
             );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = 1
                },
                new Vehicle
                {
                    Id = 2,
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = 1
                },
                new Vehicle
                {
                    Id = 3,
                    VehicleType = "E-Scooter",
                    Status = "Available",
                    PricePerMinute = 1500,
                    StationId = 2
                },
                new Vehicle
                {
                    Id = 4,
                    VehicleType = "E-Scooter",
                    Status = "Available",
                    PricePerMinute = 1500,
                    StationId = 2
                }
            );


        }
    }
}