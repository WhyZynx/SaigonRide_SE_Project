namespace SaigonRideProject.ViewModels
{
    public class BillViewModel
    {
        public int RentalId { get; set; }
        public int ReturnStationId { get; set; }
        public double DurationSeconds { get; set; }

        public decimal BaseAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal Discount { get; set; }
    }
}