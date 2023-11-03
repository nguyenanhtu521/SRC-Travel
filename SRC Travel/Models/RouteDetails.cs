using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC_Travel.Models
{
    public class RouteDetails
    {
        [Key]
        public int RouteDetailID { get; set; }
        [ForeignKey("BusRouteID")]
        public int BusRouteID { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set;}
        public double Distance { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public string? Flag { get; set; }

        public virtual BusRoutes? BusRoutes { get; set; }
    }
}
