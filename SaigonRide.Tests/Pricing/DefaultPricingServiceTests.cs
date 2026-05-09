using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Pricing;
using SaigonRideProject.Models;

namespace SaigonRide.Tests.Pricing
{
    public class DefaultPricingServiceTests
    {
        private AppDbContext GetDb(int vehicleCount, int capacity)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new AppDbContext(options);

            var station = new Station
            {
                Name = "Test Station",
                Address = "Test Address",
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
                    PlateNumber = "DEF" + i
                });
            }

            db.SaveChanges();
            return db;
        }

        private User CreateUser()
        {
            return new User
            {
                FullName = "Test",
                Email = "test@gmail.com",
                PasswordHash = "123",
                UserType = "Local"
            };
        }

        [Fact]
        public void Calculate_NoDiscount()
        {
            var db = GetDb(5, 10); // 50%
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA111"
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
            var db = GetDb(1, 10); // 10%
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA111"
                },
                TimeSpan.FromMinutes(10),
                station,
                CreateUser()
            );

            Assert.Equal(4250, result.FinalAmount);
        }

        [Fact]
        public void Calculate_Boundary_MinTime()
        {
            var db = GetDb(1, 10);
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA111"
                },
                TimeSpan.FromMinutes(1),
                station,
                CreateUser()
            );

            Assert.Equal(425, result.FinalAmount);
        }

        [Fact]
        public void Calculate_Boundary_Exactly20Percent()
        {
            var db = GetDb(2, 10); 
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
                new Vehicle
                {
                    VehicleType = "Bike",
                    Status = "Available",
                    PricePerMinute = 500,
                    StationId = station.Id,
                    PlateNumber = "AAA111"
                },
                TimeSpan.FromMinutes(10),
                station,
                CreateUser()
            );

            Assert.Equal(5000, result.FinalAmount); 
        }

        [Fact]
        public void Calculate_Boundary_JustBelow20Percent()
        {
            var db = GetDb(19, 100); // 19%
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
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

        [Fact]
        public void Calculate_Boundary_JustAbove20Percent()
        {
            var db = GetDb(21, 100); // 21%
            var service = new StationService(db);
            var pricing = new DefaultPricingService(service);

            var station = db.Stations.First();

            var result = pricing.Calculate(
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
    }
}