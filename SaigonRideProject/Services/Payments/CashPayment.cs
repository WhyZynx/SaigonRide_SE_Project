namespace SaigonRideProject.Services.Payments
{
    public class CashPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount) => true;
    }
}
