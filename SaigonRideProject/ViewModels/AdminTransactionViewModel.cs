namespace SaigonRideProject.ViewModels
{
    public class AdminTransactionViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string VehicleType { get; set; }
        public DateTime EndTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}