namespace SaigonRideProject.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string Status { get; set; }
        public decimal PricePerMinute { get; set; }
        public int StationId { get; set; }
        public Station? Station { get; set; }
    }
}
