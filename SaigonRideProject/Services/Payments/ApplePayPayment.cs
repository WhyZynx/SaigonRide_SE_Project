namespace SaigonRideProject.Services.Payments
{
    public class ApplePayPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount) => true;
    }
}
