
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC_Travel.Models
{
    public class Buses
    {
        [Key]
        public int BusID { get; set; }
        public string BusName { get; set; }
        [ForeignKey(nameof(BusTypeID))]
        public int BusTypeID { get; set; }
        public int TotalSeats { get; set; }
        [ForeignKey(nameof(BusRouteID))]
        public int BusRouteID { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        
        public virtual BusType? BusType { get; set; }
        public virtual BusRoutes? BusRoutes { get; set; }
    }
}
