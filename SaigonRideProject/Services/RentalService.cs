using SaigonRideProject.Models;
using SaigonRideProject.Services.Payments;
using SaigonRideProject.Services.Pricing;
using SaigonRideProject.Data;

namespace SaigonRideProject.Services
{
    public class RentalService
    {
        private readonly AppDbContext _context;
        private readonly IPricingStrategy _pricing;

        public RentalService(AppDbContext context,
                             IPricingStrategy pricing)
        {
            _context = context;
            _pricing = pricing;
        }

        public Rental Create(int userId, int vehicleId, int stationId)
        {
            var vehicle = _context.Vehicles.Find(vehicleId);

            if (vehicle == null)
                throw new Exception("Vehicle not found");

            if (vehicle.Status != "Available")
                throw new Exception("Vehicle not available");

            var rental = new Rental
            {
                UserId = userId,
                VehicleId = vehicleId,
                PickupStationId = stationId,
                StartTime = DateTime.Now,
                Status = "InProgress"
            };

            vehicle.Status = "InTransit";

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return rental;
        }

        public decimal Complete(int rentalId, int returnStationId)
        {
            var rental = _context.Rentals.Find(rentalId)
                ?? throw new Exception("Rental not found");

            var vehicle = _context.Vehicles.Find(rental.VehicleId)
                ?? throw new Exception("Vehicle not found");

            var station = _context.Stations.Find(returnStationId)
                ?? throw new Exception("Station not found");

            rental.EndTime = DateTime.Now;

            var duration = rental.EndTime.Value - rental.StartTime;

            var fare = _pricing.Calculate(vehicle, duration, station);

            rental.TotalFare = fare;
            rental.ReturnStationId = returnStationId;
            rental.Status = "Completed";

            vehicle.Status = "Available";

            _context.SaveChanges();

            return fare;
        }

     
    }
}
