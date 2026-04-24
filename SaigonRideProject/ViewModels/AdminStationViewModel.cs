using SaigonRideProject.Models;

namespace SaigonRideProject.ViewModels
{
    public class AdminStationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int CurrentInventory { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new();
        public string SearchKeyword { get; set; }
        public string Status { get; set; }
    }
}
