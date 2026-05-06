using Xunit;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;

public class WalletServiceTests
{
    private AppDbContext GetDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("WalletDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void CanPay_True()
    {
        var service = new WalletService(GetDb());
        var user = TestHelpers.CreateUser();
        user.Balance = 10000;

        Assert.True(service.CanPay(user, 5000));
    }

    [Fact]
    public void Pay_ReducesBalance()
    {
        var db = GetDb();
        var service = new WalletService(db);
        var user = TestHelpers.CreateUser();
        user.Balance = 10000;

        service.Pay(user, 5000, "Cash");

        Assert.Equal(5000, user.Balance);
    }
}