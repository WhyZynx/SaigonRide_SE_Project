namespace SaigonRideProject.Models
{
    public class WalletTransaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } 

        public string Method { get; set; } 

        public DateTime CreatedAt { get; set; }
    }
}
