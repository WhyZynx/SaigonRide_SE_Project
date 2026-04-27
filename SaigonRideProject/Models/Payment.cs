namespace SaigonRideProject.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public int RentalId { get; set; }
        public Rental Rental { get; set; }

        public string QrCodeUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}