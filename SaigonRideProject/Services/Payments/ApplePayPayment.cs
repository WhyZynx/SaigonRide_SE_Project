namespace SaigonRideProject.Services.Payments
{
    public class ApplePayPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} VND via ApplePay";
        }
    }
}
