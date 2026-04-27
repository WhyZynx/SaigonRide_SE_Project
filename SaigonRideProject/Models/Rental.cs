namespace SaigonRideProject.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int PickupStationId { get; set; }
        public Station? PickupStation { get; set; }

        public int? ReturnStationId { get; set; }
        public Station? ReturnStation { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public decimal BaseAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FinalAmount { get; set; }

  
        public string? PaymentMethod { get; set; }

        public string Status { get; set; } = "InProgress";
        public ICollection<Payment> Payments { get; set; }
    }
}