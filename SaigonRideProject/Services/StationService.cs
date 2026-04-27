using SaigonRideProject.Models;

namespace SaigonRideProject.Services
{
    public class StationService
    {
        public double GetFillPercent(Station station)
        {
            if (station.Capacity == 0) return 0;
            return (double)station.CurrentInventory / station.Capacity;
        }

        public bool IsLowCapacity(Station station)
        {
            return GetFillPercent(station) < 0.2;
        }
    }
}
