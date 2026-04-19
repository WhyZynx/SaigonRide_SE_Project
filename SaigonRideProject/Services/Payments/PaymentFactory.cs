using SaigonRideProject.Services.Payments;

namespace SaigonRideProject.Services.Payment
{
    public static class PaymentFactory
    {
        public static IPaymentStrategy GetStrategy(string userType, string method)
        {
            return userType switch
            {
                "Local" => method switch
                {
                    "MoMo" => new MoMoPayment(),
                    "VNPay" => new VNPayPayment(),
                    "Cash" => new CashPayment(),
                    _ => throw new Exception("Invalid Local method")
                },

                "Tourist" => method switch
                {
                    "ApplePay" => new ApplePayPayment(),
                    "PayPal" => new PayPalPayment(),
                    "Cash" => new CashPayment(),
                    _ => throw new Exception("Invalid Tourist method")
                },

                _ => throw new Exception("Invalid user type")
            };
        }
    }
}