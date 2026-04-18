using System.ComponentModel.DataAnnotations;

namespace SaigonRideProject.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public required string VehicleType { get; set; }

        [Required]
        public required string Status { get; set; }

        public decimal PricePerMinute { get; set; }

        public int StationId { get; set; }

        public Station? Station { get; set; }

        public required string PlateNumber { get; set; }
    }
}