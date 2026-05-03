namespace SaigonRideProject.Services
{
    public static class DashboardUpdateService
    {
        private static readonly object _lock = new object();

        private static long _stationUpdated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private static long _vehicleUpdated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        public static long GetStationUpdated() => _stationUpdated;
        public static long GetVehicleUpdated() => _vehicleUpdated;
        public static void NotifyStation()
        {
            lock (_lock)
            {
                _stationUpdated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
        }

        public static void NotifyVehicle()
        {
            lock (_lock)
            {
                _vehicleUpdated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
        }
    }
}