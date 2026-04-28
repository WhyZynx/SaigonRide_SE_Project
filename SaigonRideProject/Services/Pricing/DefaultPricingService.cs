using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public class DefaultPricingService : IPricingStrategy
    {
        private readonly StationService _stationService;

        public DefaultPricingService(StationService stationService)
        {
            _stationService = stationService;
        }

        public PricingResult Calculate(
            Vehicle vehicle,
            TimeSpan duration,
            Station returnStation,
            User user
        )
        {
            var baseAmount = vehicle.PricePerMinute * (decimal)duration.TotalMinutes;

            decimal discount = 0;

            if (_stationService.IsLowCapacity(returnStation))
            {
                discount = 0.15m;
            }

            return new PricingResult
            {
                BaseAmount = baseAmount,
                DiscountPercent = discount,
                FinalAmount = baseAmount * (1 - discount)
            };
        }
    }
}