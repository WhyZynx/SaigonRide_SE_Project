using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Services.Payments
{
    public class VNPayPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} via VNPay";
        }
    }
}
