namespace SaigonRideProject.Models
{
    public class OtpVerification
    {
        public int Id { get; set; }

        public required string Email { get; set; }

        public required string OtpCode { get; set; }

        public DateTime ExpiryTime { get; set; }
    }
}