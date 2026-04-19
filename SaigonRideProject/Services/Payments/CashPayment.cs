using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Services.Payments
{
    public class CashPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} via Cash";
        }
    }
}
