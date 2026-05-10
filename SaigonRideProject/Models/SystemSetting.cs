using System.ComponentModel.DataAnnotations.Schema;

namespace SaigonRideProject.Models
{
    [Table("SystemSettings", Schema = "dbo")]
    public class SystemSetting
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Currency { get; set; }

        public string Language { get; set; }

        public string TimeZone { get; set; }
    }
}