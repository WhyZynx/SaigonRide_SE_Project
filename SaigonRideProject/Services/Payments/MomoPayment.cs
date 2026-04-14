namespace SaigonRideProject.Services.Payments
{
    public class MomoPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount) => true;
    }
}
