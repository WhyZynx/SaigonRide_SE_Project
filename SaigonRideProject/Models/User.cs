namespace SaigonRideProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string UserType { get; set; }
        public bool IsVerified { get; set; }
        public string? PassportNumber { get; set; }
    }
}