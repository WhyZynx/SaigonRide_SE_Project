using SaigonRideProject.Models;

namespace SaigonRideProject.ViewModels
{
    public class UserDashboardViewModel
    {
        public User User { get; set; }

        public List<StationMapViewModel> Stations { get; set; }
    }
}