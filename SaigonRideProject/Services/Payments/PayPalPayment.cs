using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Services.Payments
{
    public class PayPalPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} via PayPal";
        }
    }
}
