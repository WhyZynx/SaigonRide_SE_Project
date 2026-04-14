namespace SaigonRideProject.Services.Payments
{
    public class PaymentContext
    {
        private IPaymentStrategy? _strategy;

        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool ExecutePayment(decimal amount)
        {
            if (_strategy == null)
                throw new Exception("Payment strategy not set");

            return _strategy.Pay(amount);
        }
    }
}