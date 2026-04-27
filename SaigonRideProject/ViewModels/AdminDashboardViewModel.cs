namespace SaigonRideProject.ViewModels
{
    public class AdminDashboardViewModel
    {
        public decimal TodayRevenue { get; set; }
        public int ActiveRentals { get; set; }
        public int AvailableVehicles { get; set; }
        public int TotalTransactions { get; set; }
        public bool HasLowStations { get; set; }
        public List<StationStatusViewModel> LowStations { get; set; }
        public List<AdminTransactionViewModel> RecentTransactions { get; set; }
        public List<LiveRentalViewModel> LiveRentals { get; set; }
    }
}