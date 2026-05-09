using SaigonRideProject.Models;

public static class TestHelpers
{
    public static Vehicle CreateVehicle(decimal price)
    {
        return new Vehicle
        {
            VehicleType = "Bike",
            Status = "Available",
            PricePerMinute = price,
            StationId = 1,
            PlateNumber = "ABC123"
        };
    }

    public static Station CreateStation()
    {
        return new Station
        {
            Name = "Test Station",
            Address = "Test Address",
            Capacity = 10
        };
    }

    public static User CreateUser()
    {
        return new User
        {
            FullName = "Test",
            Email = "test@gmail.com",
            PasswordHash = "123",
            UserType = "Local"
        };
    }
}