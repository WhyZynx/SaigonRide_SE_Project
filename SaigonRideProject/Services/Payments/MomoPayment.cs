namespace SaigonRideProject.Services.Payments
{
    public class MoMoPayment : IPaymentStrategy
    {
        public string Pay(decimal amount)
        {
            return "Paid " + amount + " VND via MoMo";
        }
    }
}
