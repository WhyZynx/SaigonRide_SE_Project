using System.Collections.Generic;

namespace SaigonRideProject.ViewModels
{
    public class StationDetailViewModel
    {
        public StationMapViewModel Station { get; set; }
        public List<VehicleViewModel> Vehicles { get; set; }
        public int AvailableCount { get; set; }
        public int Capacity { get; set; }
        public int VehicleCount { get; set; }
        public int BatteryLevel { get; set; }
    }
}