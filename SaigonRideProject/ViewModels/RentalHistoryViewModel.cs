namespace SaigonRideProject.ViewModels
{
    public class RentalHistoryViewModel
    {
        public string VehicleType { get; set; }
        public string PlateNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public decimal BaseAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FinalAmount { get; set; }

        public string PaymentMethod { get; set; }
    }
}
