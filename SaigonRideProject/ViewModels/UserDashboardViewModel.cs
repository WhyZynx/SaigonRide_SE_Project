using SaigonRideProject.Models;

namespace SaigonRideProject.ViewModels
{
    public class UserDashboardViewModel
    {
        public User User { get; set; }
        public string UserType { get; set; } = string.Empty;

        public List<StationMapViewModel> Stations { get; set; }
    }
}