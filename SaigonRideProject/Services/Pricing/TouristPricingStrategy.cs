using SaigonRideProject.Models;
using SaigonRideProject.Services;

namespace SaigonRideProject.Services.Pricing
{
    public class TouristPricingStrategy : IPricingStrategy
    {
        private readonly StationService _stationService;

        public TouristPricingStrategy(StationService stationService)
        {
            _stationService = stationService;
        }

        public PricingResult Calculate(Vehicle vehicle, TimeSpan duration, Station returnStation, User user)
        {
            var baseAmount = vehicle.PricePerMinute * (decimal)duration.TotalMinutes;

            decimal discount = 0;

            if (_stationService.IsLowCapacity(returnStation))
            {
                discount = 0.15m;
            }

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