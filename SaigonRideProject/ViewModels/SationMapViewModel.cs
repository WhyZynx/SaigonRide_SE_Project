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
        public int CurrentInventory { get; set; }

        public int AvailableCount { get; set; }

        public string Status
        {
            get
            {
                double ratio = (double)CurrentInventory / Capacity;

                if (ratio < 0.2) return "Low";
                if (ratio > 0.8) return "High";
                return "Normal";
            }
        }
    }
}
