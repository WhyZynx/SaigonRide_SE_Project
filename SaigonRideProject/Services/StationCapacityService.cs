using SaigonRideProject.Data;
using SaigonRideProject.Models;
using Microsoft.EntityFrameworkCore;

public class StationCapacityService
{
    private readonly AppDbContext _context;

    public StationCapacityService(AppDbContext context)
    {
        _context = context;
    }

    private Station GetStation(int stationId)
    {
        return _context.Stations
            .Include(s => s.Vehicles)
            .FirstOrDefault(s => s.Id == stationId);
    }

    public bool CanReceiveVehicle(int stationId)
    {
        var station = GetStation(stationId);
        return station != null && station.Vehicles.Count < station.Capacity;
    }

    public int GetAvailableSlots(int stationId)
    {
        var station = GetStation(stationId);
        return station == null ? 0 : station.Capacity - station.Vehicles.Count;
    }

    public double GetFillPercent(int stationId)
    {
        var station = GetStation(stationId);
        if (station == null || station.Capacity == 0) return 0;

        return (double)station.Vehicles.Count / station.Capacity;
    }

    public bool IsLowInventory(int stationId)
    {
        return GetFillPercent(stationId) < 0.2;
    }
}