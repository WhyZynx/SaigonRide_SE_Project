namespace SaigonRideProject.Services.Payments
{
    public interface IPaymentStrategy
    {
        bool Pay(decimal amount);
    }
}