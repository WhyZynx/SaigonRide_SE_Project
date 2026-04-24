namespace SaigonRideProject.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }

        public bool IsVerified { get; set; }
        public bool IsLocked { get; set; }

        public string PassportNumber { get; set; }
        public string PassportStatus { get; set; }

        public decimal Balance { get; set; }
    }
}