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

        public Rental StartRental(int userId, int vehicleId, int stationId)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            var station = _context.Stations.FirstOrDefault(s => s.Id == stationId);

            if (vehicle == null || station == null)
                return null;

            vehicle.Status = "Rented";
            station.CurrentInventory--;

            var rental = new Rental
            {
                UserId = userId,
                VehicleId = vehicleId,
                PickupStationId = stationId,
                StartTime = DateTime.Now
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return rental;
        }

        public bool EndRental(int rentalId, int returnStationId)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null) return false;

            var returnStation = _context.Stations.FirstOrDefault(s => s.Id == returnStationId);
            var pickup = _context.Stations.FirstOrDefault(s => s.Id == rental.PickupStationId);

            if (returnStation == null || pickup == null) return false;

            // ===== VEHICLE =====
            rental.Vehicle.Status = "Available";

            // ===== INVENTORY =====
            returnStation.CurrentInventory++;

            // ❌ KHÔNG TRỪ pickup nữa (đã trừ khi start)
            // pickup.CurrentInventory--;

            // ===== RENTAL =====
            rental.EndTime = DateTime.Now;
            rental.ReturnStationId = returnStationId;

            _context.SaveChanges();

            return true;
        }
    }
}