using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public static class PricingFactory
    {
        public static IPricingStrategy GetStrategy(User user)
        {
            return new DefaultPricingService();
        }
    }
}