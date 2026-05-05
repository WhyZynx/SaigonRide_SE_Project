using Xunit;
using SaigonRideProject.Services.Payment;

public class PaymentMethodProviderTests
{
    [Fact]
    public void Get_Local_Methods()
    {
        var methods = PaymentMethodProvider.Get("Local");

        Assert.Contains("MoMo", methods);
        Assert.Contains("VNPay", methods);
    }

    [Fact]
    public void Get_Tourist_Methods()
    {
        var methods = PaymentMethodProvider.Get("Tourist");

        Assert.Contains("PayPal", methods);
        Assert.Contains("ApplePay", methods);
    }
}