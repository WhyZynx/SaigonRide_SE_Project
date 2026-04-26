using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public class LocalPricingStrategy : IPricingStrategy
    {
        public PricingResult Calculate(Vehicle vehicle, TimeSpan duration, Station returnStation, User user)
        {
            var baseAmount = vehicle.PricePerMinute * (decimal)duration.TotalMinutes;

            decimal discount = 0;

            if ((double)returnStation.CurrentInventory / returnStation.Capacity < 0.2)
                discount = 0.15m;

            var finalAmount = baseAmount * (1 - discount);

            return new PricingResult
            {
                BaseAmount = baseAmount,
                FinalAmount = finalAmount,
                DiscountPercent = discount
            };
        }
    }
}