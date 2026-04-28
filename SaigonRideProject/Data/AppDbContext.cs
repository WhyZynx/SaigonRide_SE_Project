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
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.BatteryLevel)
                .HasDefaultValue(100);

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

            // chỉ 1 rental đang chạy
            modelBuilder.Entity<Rental>()
                .HasIndex(r => r.UserId)
                .HasFilter("[Status] = 'InProgress'")
                .IsUnique();

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Vehicle)
                .WithMany()
                .HasForeignKey(r => r.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.PickupStation)
                .WithMany()
                .HasForeignKey(r => r.PickupStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.ReturnStation)
                .WithMany()
                .HasForeignKey(r => r.ReturnStationId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= PAYMENT (NEW - QUAN TRỌNG) =================
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Rental)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.RentalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasDefaultValue("Pending");

            // ================= WALLET =================
            modelBuilder.Entity<WalletTransaction>()
                .Property(w => w.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<WalletTransaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.WalletTransactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================= SEED USER =================
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
                new Station { Id = 1, Name = "Ben Thanh Station", Address = "District 1", Capacity = 25, Latitude = 10.7720, Longitude = 106.6980 },
                new Station { Id = 2, Name = "District 3 Hub", Address = "Vo Van Tan", Capacity = 20,  Latitude = 10.7825, Longitude = 106.6900 },
                new Station { Id = 3, Name = "Binh Thanh Station", Address = "Dien Bien Phu", Capacity = 18,  Latitude = 10.8031, Longitude = 106.7150 },
                new Station { Id = 4, Name = "Thu Duc Station", Address = "Vo Nguyen Giap", Capacity = 30,  Latitude = 10.8500, Longitude = 106.7700 },
                new Station { Id = 5, Name = "Tan Binh Station", Address = "Cong Hoa", Capacity = 22,  Latitude = 10.8010, Longitude = 106.6520 },
                new Station { Id = 6, Name = "District 7 Station", Address = "Nguyen Van Linh", Capacity = 20,  Latitude = 10.7295, Longitude = 106.7210 },

                new Station { Id = 7, Name = "Phu Nhuan Station", Address = "Phan Xich Long", Capacity = 18, Latitude = 10.7990, Longitude = 106.6800 },
                new Station { Id = 8, Name = "Go Vap Station", Address = "Quang Trung", Capacity = 22, Latitude = 10.8380, Longitude = 106.6680 },
                new Station { Id = 9, Name = "District 5 Station", Address = "Tran Hung Dao", Capacity = 18, Latitude = 10.7550, Longitude = 106.6700 },
                new Station { Id = 10, Name = "District 10 Station", Address = "Su Van Hanh", Capacity = 18, Latitude = 10.7705, Longitude = 106.6650 },
                new Station { Id = 11, Name = "Tan Phu Station", Address = "Lu Gia", Capacity = 20, Latitude = 10.7900, Longitude = 106.6300 },
                new Station { Id = 12, Name = "Binh Tan Station", Address = "Kinh Duong Vuong", Capacity = 25, Latitude = 10.7600, Longitude = 106.6000 }
            );


            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, VehicleType = "Bike", PlateNumber = "BK-001", Status = "Available", PricePerMinute = 500, StationId = 1, BatteryLevel = 90 },
                new Vehicle { Id = 2, VehicleType = "Bike", PlateNumber = "BK-002", Status = "Available", PricePerMinute = 500, StationId = 1, BatteryLevel = 85 },
                new Vehicle { Id = 3, VehicleType = "Bike", PlateNumber = "BK-003", Status = "InUse", PricePerMinute = 500, StationId = 1, BatteryLevel = 70 },
                new Vehicle { Id = 4, VehicleType = "E-Scooter", PlateNumber = "SC-001", Status = "Available", PricePerMinute = 1500, StationId = 1, BatteryLevel = 95 },
                new Vehicle { Id = 5, VehicleType = "E-Scooter", PlateNumber = "SC-002", Status = "Maintenance", PricePerMinute = 1500, StationId = 1, BatteryLevel = 40 },

                // ================= Station 2 =================
                new Vehicle { Id = 6, VehicleType = "Bike", PlateNumber = "BK-101", Status = "Available", PricePerMinute = 500, StationId = 2, BatteryLevel = 88 },
                new Vehicle { Id = 7, VehicleType = "Bike", PlateNumber = "BK-102", Status = "Available", PricePerMinute = 500, StationId = 2, BatteryLevel = 92 },
                new Vehicle { Id = 8, VehicleType = "Bike", PlateNumber = "BK-103", Status = "InUse", PricePerMinute = 500, StationId = 2, BatteryLevel = 60 },
                new Vehicle { Id = 9, VehicleType = "E-Scooter", PlateNumber = "SC-101", Status = "Available", PricePerMinute = 1500, StationId = 2, BatteryLevel = 75 },
                new Vehicle { Id = 10, VehicleType = "E-Scooter", PlateNumber = "SC-102", Status = "Maintenance", PricePerMinute = 1500, StationId = 2, BatteryLevel = 30 },

                // ================= Station 3 =================
                new Vehicle { Id = 11, VehicleType = "Bike", PlateNumber = "BK-201", Status = "Available", PricePerMinute = 500, StationId = 3, BatteryLevel = 90 },
                new Vehicle { Id = 12, VehicleType = "Bike", PlateNumber = "BK-202", Status = "Available", PricePerMinute = 500, StationId = 3, BatteryLevel = 85 },
                new Vehicle { Id = 13, VehicleType = "Bike", PlateNumber = "BK-203", Status = "Available", PricePerMinute = 500, StationId = 3, BatteryLevel = 80 },
                new Vehicle { Id = 14, VehicleType = "E-Scooter", PlateNumber = "SC-201", Status = "InUse", PricePerMinute = 1500, StationId = 3, BatteryLevel = 65 },
                new Vehicle { Id = 15, VehicleType = "E-Scooter", PlateNumber = "SC-202", Status = "Available", PricePerMinute = 1500, StationId = 3, BatteryLevel = 95 },

                // ================= Station 4 =================
                new Vehicle { Id = 16, VehicleType = "Bike", PlateNumber = "BK-301", Status = "Available", PricePerMinute = 500, StationId = 4, BatteryLevel = 88 },
                new Vehicle { Id = 17, VehicleType = "Bike", PlateNumber = "BK-302", Status = "InUse", PricePerMinute = 500, StationId = 4, BatteryLevel = 70 },
                new Vehicle { Id = 18, VehicleType = "Bike", PlateNumber = "BK-303", Status = "Available", PricePerMinute = 500, StationId = 4, BatteryLevel = 92 },
                new Vehicle { Id = 19, VehicleType = "E-Scooter", PlateNumber = "SC-301", Status = "Available", PricePerMinute = 1500, StationId = 4, BatteryLevel = 85 },
                new Vehicle { Id = 20, VehicleType = "E-Scooter", PlateNumber = "SC-302", Status = "Available", PricePerMinute = 1500, StationId = 4, BatteryLevel = 90 },

                // ================= Station 5 =================
                new Vehicle { Id = 21, VehicleType = "Bike", PlateNumber = "BK-401", Status = "Maintenance", PricePerMinute = 500, StationId = 5, BatteryLevel = 20 },
                new Vehicle { Id = 22, VehicleType = "Bike", PlateNumber = "BK-402", Status = "Available", PricePerMinute = 500, StationId = 5, BatteryLevel = 80 },
                new Vehicle { Id = 23, VehicleType = "Bike", PlateNumber = "BK-403", Status = "Available", PricePerMinute = 500, StationId = 5, BatteryLevel = 85 },
                new Vehicle { Id = 24, VehicleType = "E-Scooter", PlateNumber = "SC-401", Status = "InUse", PricePerMinute = 1500, StationId = 5, BatteryLevel = 60 },
                new Vehicle { Id = 25, VehicleType = "E-Scooter", PlateNumber = "SC-402", Status = "Available", PricePerMinute = 1500, StationId = 5, BatteryLevel = 95 },

                // ================= Station 6 =================
                new Vehicle { Id = 26, VehicleType = "Bike", PlateNumber = "BK-501", Status = "Available", PricePerMinute = 500, StationId = 6, BatteryLevel = 90 },
                new Vehicle { Id = 27, VehicleType = "Bike", PlateNumber = "BK-502", Status = "Available", PricePerMinute = 500, StationId = 6, BatteryLevel = 85 },
                new Vehicle { Id = 28, VehicleType = "Bike", PlateNumber = "BK-503", Status = "Available", PricePerMinute = 500, StationId = 6, BatteryLevel = 80 },
                new Vehicle { Id = 29, VehicleType = "E-Scooter", PlateNumber = "SC-501", Status = "InUse", PricePerMinute = 1500, StationId = 6, BatteryLevel = 65 },
                new Vehicle { Id = 30, VehicleType = "E-Scooter", PlateNumber = "SC-502", Status = "Available", PricePerMinute = 1500, StationId = 6, BatteryLevel = 95 },

                // ================= Station 7 =================
                new Vehicle { Id = 31, VehicleType = "Bike", PlateNumber = "BK-601", Status = "Available", PricePerMinute = 500, StationId = 7, BatteryLevel = 88 },
                new Vehicle { Id = 32, VehicleType = "Bike", PlateNumber = "BK-602", Status = "Available", PricePerMinute = 500, StationId = 7, BatteryLevel = 90 },
                new Vehicle { Id = 33, VehicleType = "Bike", PlateNumber = "BK-603", Status = "Available", PricePerMinute = 500, StationId = 7, BatteryLevel = 85 },
                new Vehicle { Id = 34, VehicleType = "E-Scooter", PlateNumber = "SC-601", Status = "Maintenance", PricePerMinute = 1500, StationId = 7, BatteryLevel = 25 },
                new Vehicle { Id = 35, VehicleType = "E-Scooter", PlateNumber = "SC-602", Status = "Available", PricePerMinute = 1500, StationId = 7, BatteryLevel = 95 },

                // ================= Station 8 =================
                new Vehicle { Id = 36, VehicleType = "Bike", PlateNumber = "BK-701", Status = "Available", PricePerMinute = 500, StationId = 8, BatteryLevel = 90 },
                new Vehicle { Id = 37, VehicleType = "Bike", PlateNumber = "BK-702", Status = "Available", PricePerMinute = 500, StationId = 8, BatteryLevel = 85 },
                new Vehicle { Id = 38, VehicleType = "Bike", PlateNumber = "BK-703", Status = "Available", PricePerMinute = 500, StationId = 8, BatteryLevel = 80 },
                new Vehicle { Id = 39, VehicleType = "E-Scooter", PlateNumber = "SC-701", Status = "InUse", PricePerMinute = 1500, StationId = 8, BatteryLevel = 70 },
                new Vehicle { Id = 40, VehicleType = "E-Scooter", PlateNumber = "SC-702", Status = "Available", PricePerMinute = 1500, StationId = 8, BatteryLevel = 95 },

                // ================= Station 9 =================
                new Vehicle { Id = 41, VehicleType = "Bike", PlateNumber = "BK-801", Status = "Available", PricePerMinute = 500, StationId = 9, BatteryLevel = 88 },
                new Vehicle { Id = 42, VehicleType = "Bike", PlateNumber = "BK-802", Status = "Available", PricePerMinute = 500, StationId = 9, BatteryLevel = 90 },
                new Vehicle { Id = 43, VehicleType = "Bike", PlateNumber = "BK-803", Status = "Available", PricePerMinute = 500, StationId = 9, BatteryLevel = 85 },
                new Vehicle { Id = 44, VehicleType = "E-Scooter", PlateNumber = "SC-801", Status = "Available", PricePerMinute = 1500, StationId = 9, BatteryLevel = 95 },
                new Vehicle { Id = 45, VehicleType = "E-Scooter", PlateNumber = "SC-802", Status = "Available", PricePerMinute = 1500, StationId = 9, BatteryLevel = 90 },

                // ================= Station 10 =================
                new Vehicle { Id = 46, VehicleType = "Bike", PlateNumber = "BK-901", Status = "Available", PricePerMinute = 500, StationId = 10, BatteryLevel = 80 },
                new Vehicle { Id = 47, VehicleType = "Bike", PlateNumber = "BK-902", Status = "Available", PricePerMinute = 500, StationId = 10, BatteryLevel = 85 },
                new Vehicle { Id = 48, VehicleType = "Bike", PlateNumber = "BK-903", Status = "Available", PricePerMinute = 500, StationId = 10, BatteryLevel = 90 },
                new Vehicle { Id = 49, VehicleType = "E-Scooter", PlateNumber = "SC-901", Status = "Available", PricePerMinute = 1500, StationId = 10, BatteryLevel = 95 },
                new Vehicle { Id = 50, VehicleType = "E-Scooter", PlateNumber = "SC-902", Status = "InUse", PricePerMinute = 1500, StationId = 10, BatteryLevel = 60 }
           );


        }
    }
}