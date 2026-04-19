using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Services.Payments
{
    public class ApplePayPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} via ApplePay";
        }
    }
}
