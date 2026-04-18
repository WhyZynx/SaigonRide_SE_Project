using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public class DefaultPricingService : IPricingStrategy
    {
        public decimal Calculate(Vehicle vehicle, TimeSpan duration, Station returnStation)
        {
            decimal fare = vehicle.PricePerMinute * (decimal)duration.TotalMinutes;

            if ((double)returnStation.CurrentInventory / returnStation.Capacity < 0.2)
            {
                fare *= 0.85m;
            }

            return fare;
        }
    }
}
