namespace SaigonRideProject.ViewModels
{
    public class StationMapViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int Capacity { get; set; }
        public int VehicleCount { get; set; }

        public int AvailableCount { get; set; }

        public double FillPercent { get; set; }
        public bool IsLowCapacity { get; set; }
    }
}