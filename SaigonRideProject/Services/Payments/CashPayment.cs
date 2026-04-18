namespace SaigonRideProject.Services.Payments
{
    public class CashPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return "Paid " + amount + " VND via Cash";
        }
    }
}
