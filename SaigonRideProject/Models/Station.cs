using System.ComponentModel.DataAnnotations;

namespace SaigonRideProject.Models
{
    public class Station
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public int Capacity { get; set; }

        public int CurrentInventory { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}