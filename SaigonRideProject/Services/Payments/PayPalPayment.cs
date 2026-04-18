namespace SaigonRideProject.Services.Payments
{
    public class PayPalPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return "Paid " + amount + " VND via PayPal";
        }
    }
}
