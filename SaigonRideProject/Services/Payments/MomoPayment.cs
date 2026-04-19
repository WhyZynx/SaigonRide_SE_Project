using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Services.Payments
{
    public class MoMoPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} via MoMo";
        }
    }
}
