namespace SaigonRideProject.ViewModels
{
    public class AdminVehicleViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string PlateNumber { get; set; }
        public string Status { get; set; }
        public decimal PricePerMinute { get; set; }
        public int StationId { get; set; }
        public int BatteryLevel { get; set; }
        public string StationName { get; set; }
        public string SearchKeyword { get; set; }
        public string VehicleTypeFilter { get; set; }
        public string StatusFilter { get; set; }
    }
}
