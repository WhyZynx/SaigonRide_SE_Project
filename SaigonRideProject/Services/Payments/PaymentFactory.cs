using SaigonRideProject.Services.Payments;

namespace SaigonRideProject.Services.Payment
{
    public class PaymentFactory
    {
        public static IPaymentStrategy GetStrategy(string method)
        {
            return method switch
            {
                "Cash" => new CashPayment(),
                "MoMo" => new MoMoPayment(),
                "VNPay" => new VNPayPayment(),
                "PayPal" => new PayPalPayment(),
                _ => throw new Exception("Invalid payment method")
            };
        }
    }
}