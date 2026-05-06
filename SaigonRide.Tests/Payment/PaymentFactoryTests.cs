using Xunit;
using SaigonRideProject.Services.Payment;

public class PaymentFactoryTests
{
    [Fact]
    public void GetStrategy_Local_MoMo()
    {
        var strategy = PaymentFactory.GetStrategy("Local", "MoMo");

        var result = strategy.Pay(1000);

        Assert.Contains("Paid", result);
    }

    [Fact]
    public void GetStrategy_Tourist_ApplePay()
    {
        var strategy = PaymentFactory.GetStrategy("Tourist", "ApplePay");

        var result = strategy.Pay(1000);

        Assert.Contains("ApplePay", result);
    }
}