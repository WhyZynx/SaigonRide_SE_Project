using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Models;

namespace SaigonRide.Tests.Pricing
{
    public class LocalPricingStrategyTests
    {
        private AppDbContext GetDb(int vehicleCount, int capacity)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new AppDbContext(options);

            var station = new Station
            {
                Name = "Station",
                Address = "Address",
                Capacity = capacity
            };

            db.Stations.Add(station);
            db.SaveChanges();

            var stationId = station.Id;

            for (int i = 0; i < vehicleCount; i++)
            {
                db.Vehicles.Add(new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = stationId,
                    PlateNumber = "ABC" + i
                });
            }

            db.SaveChanges();
            return db;
        }

        private User CreateUser()
        {
            return new User
            {
                FullName = "User",
                Email = "user@gmail.com",
                PasswordHash = "123",
                UserType = "Local"
            };
        }

        [Fact]
        public void Calculate_NoDiscount()
        {
            var db = GetDb(5, 10);
            var strategy = new LocalPricingStrategy(new StationService(db));

            var station = db.Stations.First();

            var result = strategy.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA"
                },
                TimeSpan.FromMinutes(10),
                station,
                CreateUser()
            );

            Assert.Equal(5000, result.FinalAmount);
        }

        [Fact]
        public void Calculate_WithDiscount()
        {
            var db = GetDb(1, 10);
            var strategy = new LocalPricingStrategy(new StationService(db));

            var station = db.Stations.First();

            var result = strategy.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA"
                },
                TimeSpan.FromMinutes(10),
                station,
                CreateUser()
            );

            Assert.Equal(4250, result.FinalAmount);
        }
    }
}