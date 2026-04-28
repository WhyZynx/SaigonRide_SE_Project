using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public interface IPricingStrategy
    {
        PricingResult Calculate(
            Vehicle vehicle,
            TimeSpan duration,
            Station returnStation,
            User user
        );
    }
}