using System.ComponentModel.DataAnnotations;

namespace SaigonRideProject.Models
{
    public class Station
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

        public int Capacity { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public string Status { get; set; } = "Active";

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}