namespace SaigonRideProject.Services.Payment
{
    public static class PaymentMethodProvider
    {
        public static string[] Get(string userType)
        {
            return userType == "Local"
                ? new[] { "MoMo", "VNPay", "Cash" }
                : new[] { "PayPal", "ApplePay", "Cash" };
        }
    }
}