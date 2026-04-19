using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services.Pricing;

namespace SaigonRideProject.Services
{
    public class RentalService
    {
        private readonly AppDbContext _context;

        public RentalService(AppDbContext context)
        {
            _context = context;
        }

        public bool HasActiveRental(int userId)
        {
            return _context.Rentals.Any(r => r.UserId == userId && r.Status == "InProgress");
        }

        public void ValidateCanRent(int userId)
        {
            var active = _context.Rentals
                .Any(r => r.UserId == userId && r.Status == "InProgress");

            if (active)
                throw new Exception("User already has active rental");
        }

        public Rental StartRental(int userId, int vehicleId, int stationId)
        {
            var rental = new Rental
            {
                UserId = userId,
                VehicleId = vehicleId,
                PickupStationId = stationId,
                StartTime = DateTime.Now,
                Status = "InProgress"
            };

            _context.Rentals.Add(rental);
            return rental;
        }
    }
}