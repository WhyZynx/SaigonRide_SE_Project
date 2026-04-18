namespace SaigonRideProject.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty; 
        public decimal PricePerMinute { get; set; }
        public string Status { get; set; } = "Available";
    }
}
