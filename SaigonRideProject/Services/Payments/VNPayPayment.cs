namespace SaigonRideProject.Services.Payments
{
    public class VNPayPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return "Paid " + amount + " VND via VNPay";
        }
    }
}
