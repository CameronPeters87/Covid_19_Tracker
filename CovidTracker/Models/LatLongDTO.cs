using System.ComponentModel.DataAnnotations;

namespace CovidTracker.Models
{
    public class LatLongDTO
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}