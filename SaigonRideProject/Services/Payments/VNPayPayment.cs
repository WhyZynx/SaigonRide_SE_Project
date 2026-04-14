namespace SaigonRideProject.Services.Payments
{
    public class VNPayPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount) => true;
    }
}
