namespace SaigonRideProject.ViewModels
{
    public class CurrentTripViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public decimal PricePerMinute { get; set; }
        public double PickupLat { get; set; }
        public double PickupLng { get; set; }
        public string UserType { get; set; } = string.Empty;  

    }
}
