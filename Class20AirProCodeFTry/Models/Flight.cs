using System.ComponentModel.DataAnnotations;

namespace Class20AirProCodeFTry.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int? Price { get; set; }
        public string? Class { get; set; }
        
    }
}
