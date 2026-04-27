using SaigonRideProject.Models;
using SaigonRideProject.Data;

namespace SaigonRideProject.Services
{
    public class StationService
    {
        private readonly AppDbContext _context;

        public StationService(AppDbContext context)
        {
            _context = context;
        }

        public double GetFillPercent(Station station)
        {
            if (station.Capacity == 0) return 0;

            var vehicleCount = _context.Vehicles.Count(v => v.StationId == station.Id);

            return (double)vehicleCount / station.Capacity;
        }

        public bool IsLowCapacity(Station station)
        {
            return GetFillPercent(station) < 0.2;
        }
    }
}