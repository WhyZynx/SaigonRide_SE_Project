namespace SaigonRideProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserType { get; set; }
        public bool IsVerified { get; set; }
        public string? PassportNumber { get; set; }
    }
}
