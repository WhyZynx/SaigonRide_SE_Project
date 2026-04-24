namespace SaigonRideProject.ViewModels
{
    public class ReportViewModel
    {
        public decimal BikeRevenue { get; set; }
        public decimal ScooterRevenue { get; set; }
        public decimal TotalRevenue { get; set; }

        public List<StationRevenueVM> StationRevenues { get; set; }

        public List<StationStatusVM> StationStatuses { get; set; }
    }

    public class StationRevenueVM
    {
        public string StationName { get; set; }
        public decimal BikeRevenue { get; set; }
        public decimal ScooterRevenue { get; set; }
        public decimal Total { get; set; }
    }

    public class StationStatusVM
    {
        public string StationName { get; set; }
        public int Capacity { get; set; }
        public int Current { get; set; }
        public string Status { get; set; }
    }
}