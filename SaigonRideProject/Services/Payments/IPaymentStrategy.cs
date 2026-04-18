namespace SaigonRideProject.Services.Payments
{
    public interface IPaymentStrategy
    {
        string Pay(decimal amount);
    }
}