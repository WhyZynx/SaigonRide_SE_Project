using Xunit;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;

public class RentalServiceTests
{
    private AppDbContext GetDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("RentalDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void StartRental_CreatesRental()
    {
        var db = GetDb();
        var service = new RentalService(db);

        var rental = service.StartRental(1, 1, 1);

        Assert.Equal("InProgress", rental.Status);
    }
}