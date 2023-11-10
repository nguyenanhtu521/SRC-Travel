using System.ComponentModel.DataAnnotations;

namespace SRC_Travel.Models
{
    public class BusRoutes
    {
        [Key]
        public int BusRouteID { get; set; }
        public string BusRoutesName { get; set;}
        public string? Description { get; set;}
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
      
    }
}
