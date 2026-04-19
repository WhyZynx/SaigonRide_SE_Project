namespace SaigonRideProject.Services.Payment
{
    public interface IPaymentStrategy
    {
        string Pay(decimal amount);
    }
}