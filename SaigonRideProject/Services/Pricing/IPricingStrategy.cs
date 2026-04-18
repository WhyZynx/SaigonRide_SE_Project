using SaigonRideProject.Models;

namespace SaigonRideProject.Services.Pricing
{
    public interface IPricingStrategy
    {
        decimal Calculate(Vehicle vehicle, TimeSpan duration, Station returnStation);
    }
}
