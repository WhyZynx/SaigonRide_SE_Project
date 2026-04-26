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

        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================= USER =================
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .Property(u => u.IdentityType)
                .HasDefaultValue("None");

            modelBuilder.Entity<User>()
                .Property(u => u.PassportStatus)
                .HasDefaultValue("Pending");

            // ================= OTP =================
            modelBuilder.Entity<OtpVerification>()
                .HasIndex(o => new { o.Email, o.OtpCode });

            // ================= VEHICLE =================
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.PricePerMinute)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Station)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.StationId)
                .OnDelete(DeleteBehavior.NoAction);

            // ================= RENTAL =================
            modelBuilder.Entity<Rental>()
                .Property(r => r.BaseAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Rental>()
                .Property(r => r.FinalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Rental>()
                .Property(r => r.DiscountPercent)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Rental>()
                .HasIndex(r => r.UserId)
                .HasFilter("[Status] = 'InProgress'");

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
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

            // ================= WALLET =================
            modelBuilder.Entity<WalletTransaction>()
                .Property(w => w.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<WalletTransaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.WalletTransactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================= SEED ADMIN =================
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "System Admin",
                    Email = "admin@saigonride.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    UserType = "Local",
                    Role = "Admin",
                    IsVerified = true,
                    IdentityType = "CCCD",
                    IdentityNumber = "000000000",
                    IdentityImageUrl = "",
                    PassportStatus = "Approved",
                    Balance = 0
                }
            );
            modelBuilder.Entity<Station>().HasData(
    new Station { Id = 1, Name = "Ben Thanh Station", Address = "District 1", Capacity = 25, CurrentInventory = 18, Latitude = 10.7720, Longitude = 106.6980 },
    new Station { Id = 2, Name = "District 3 Hub", Address = "Vo Van Tan", Capacity = 20, CurrentInventory = 14, Latitude = 10.7825, Longitude = 106.6900 },
    new Station { Id = 3, Name = "Binh Thanh Station", Address = "Dien Bien Phu", Capacity = 18, CurrentInventory = 12, Latitude = 10.8031, Longitude = 106.7150 },
    new Station { Id = 4, Name = "Thu Duc Station", Address = "Vo Nguyen Giap", Capacity = 30, CurrentInventory = 20, Latitude = 10.8500, Longitude = 106.7700 },
    new Station { Id = 5, Name = "Tan Binh Station", Address = "Cong Hoa", Capacity = 22, CurrentInventory = 15, Latitude = 10.8010, Longitude = 106.6520 },
    new Station { Id = 6, Name = "District 7 Station", Address = "Nguyen Van Linh", Capacity = 20, CurrentInventory = 13, Latitude = 10.7295, Longitude = 106.7210 },

    new Station { Id = 7, Name = "Phu Nhuan Station", Address = "Phan Xich Long", Capacity = 18, CurrentInventory = 11, Latitude = 10.7990, Longitude = 106.6800 },
    new Station { Id = 8, Name = "Go Vap Station", Address = "Quang Trung", Capacity = 22, CurrentInventory = 16, Latitude = 10.8380, Longitude = 106.6680 },
    new Station { Id = 9, Name = "District 5 Station", Address = "Tran Hung Dao", Capacity = 18, CurrentInventory = 10, Latitude = 10.7550, Longitude = 106.6700 },
    new Station { Id = 10, Name = "District 10 Station", Address = "Su Van Hanh", Capacity = 18, CurrentInventory = 12, Latitude = 10.7705, Longitude = 106.6650 },
    new Station { Id = 11, Name = "Tan Phu Station", Address = "Lu Gia", Capacity = 20, CurrentInventory = 13, Latitude = 10.7900, Longitude = 106.6300 },
    new Station { Id = 12, Name = "Binh Tan Station", Address = "Kinh Duong Vuong", Capacity = 25, CurrentInventory = 17, Latitude = 10.7600, Longitude = 106.6000 }
);


            modelBuilder.Entity<Vehicle>().HasData(

               // ===== STATION 1 =====
               new Vehicle { Id = 1, VehicleType = "Bike", PlateNumber = "BK-001", Status = "Available", PricePerMinute = 500, StationId = 1 },
               new Vehicle { Id = 2, VehicleType = "Bike", PlateNumber = "BK-002", Status = "InUse", PricePerMinute = 500, StationId = 1 },
               new Vehicle { Id = 3, VehicleType = "Bike", PlateNumber = "BK-003", Status = "Maintenance", PricePerMinute = 500, StationId = 1 },
               new Vehicle { Id = 4, VehicleType = "E-Scooter", PlateNumber = "SC-001", Status = "Available", PricePerMinute = 1500, StationId = 1 },
               new Vehicle { Id = 5, VehicleType = "E-Scooter", PlateNumber = "SC-002", Status = "Available", PricePerMinute = 1500, StationId = 1 },

               // ===== STATION 2 =====
               new Vehicle { Id = 6, VehicleType = "Bike", PlateNumber = "BK-101", Status = "Available", PricePerMinute = 500, StationId = 2 },
               new Vehicle { Id = 7, VehicleType = "Bike", PlateNumber = "BK-102", Status = "InUse", PricePerMinute = 500, StationId = 2 },
               new Vehicle { Id = 8, VehicleType = "Bike", PlateNumber = "BK-103", Status = "Available", PricePerMinute = 500, StationId = 2 },
               new Vehicle { Id = 9, VehicleType = "E-Scooter", PlateNumber = "SC-101", Status = "Maintenance", PricePerMinute = 1500, StationId = 2 },
               new Vehicle { Id = 10, VehicleType = "E-Scooter", PlateNumber = "SC-102", Status = "Available", PricePerMinute = 1500, StationId = 2 },

               // ===== STATION 3 =====
               new Vehicle { Id = 11, VehicleType = "Bike", PlateNumber = "BK-201", Status = "Available", PricePerMinute = 500, StationId = 3 },
               new Vehicle { Id = 12, VehicleType = "Bike", PlateNumber = "BK-202", Status = "Available", PricePerMinute = 500, StationId = 3 },
               new Vehicle { Id = 13, VehicleType = "Bike", PlateNumber = "BK-203", Status = "InUse", PricePerMinute = 500, StationId = 3 },
               new Vehicle { Id = 14, VehicleType = "E-Scooter", PlateNumber = "SC-201", Status = "Available", PricePerMinute = 1500, StationId = 3 },
               new Vehicle { Id = 15, VehicleType = "E-Scooter", PlateNumber = "SC-202", Status = "Maintenance", PricePerMinute = 1500, StationId = 3 },

               // ===== STATION 4 =====
               new Vehicle { Id = 16, VehicleType = "Bike", PlateNumber = "BK-301", Status = "Available", PricePerMinute = 500, StationId = 4 },
               new Vehicle { Id = 17, VehicleType = "Bike", PlateNumber = "BK-302", Status = "InUse", PricePerMinute = 500, StationId = 4 },
               new Vehicle { Id = 18, VehicleType = "Bike", PlateNumber = "BK-303", Status = "Available", PricePerMinute = 500, StationId = 4 },
               new Vehicle { Id = 19, VehicleType = "E-Scooter", PlateNumber = "SC-301", Status = "Available", PricePerMinute = 1500, StationId = 4 },
               new Vehicle { Id = 20, VehicleType = "E-Scooter", PlateNumber = "SC-302", Status = "Available", PricePerMinute = 1500, StationId = 4 },

               // ===== STATION 5 =====
               new Vehicle { Id = 21, VehicleType = "Bike", PlateNumber = "BK-401", Status = "Maintenance", PricePerMinute = 500, StationId = 5 },
               new Vehicle { Id = 22, VehicleType = "Bike", PlateNumber = "BK-402", Status = "Available", PricePerMinute = 500, StationId = 5 },
               new Vehicle { Id = 23, VehicleType = "Bike", PlateNumber = "BK-403", Status = "Available", PricePerMinute = 500, StationId = 5 },
               new Vehicle { Id = 24, VehicleType = "E-Scooter", PlateNumber = "SC-401", Status = "InUse", PricePerMinute = 1500, StationId = 5 },
               new Vehicle { Id = 25, VehicleType = "E-Scooter", PlateNumber = "SC-402", Status = "Available", PricePerMinute = 1500, StationId = 5 },

               // ===== STATION 6 =====
               new Vehicle { Id = 26, VehicleType = "Bike", PlateNumber = "BK-501", Status = "Available", PricePerMinute = 500, StationId = 6 },
               new Vehicle { Id = 27, VehicleType = "Bike", PlateNumber = "BK-502", Status = "Available", PricePerMinute = 500, StationId = 6 },
               new Vehicle { Id = 28, VehicleType = "Bike", PlateNumber = "BK-503", Status = "Available", PricePerMinute = 500, StationId = 6 },
               new Vehicle { Id = 29, VehicleType = "E-Scooter", PlateNumber = "SC-501", Status = "InUse", PricePerMinute = 1500, StationId = 6 },
               new Vehicle { Id = 30, VehicleType = "E-Scooter", PlateNumber = "SC-502", Status = "Available", PricePerMinute = 1500, StationId = 6 }
           );


        }
    }
}