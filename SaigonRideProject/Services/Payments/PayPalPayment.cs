namespace SaigonRideProject.Services.Payments
{
    public class PayPalPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount) => true;
    }
}
