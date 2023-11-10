using System.ComponentModel.DataAnnotations;

namespace SRC_Travel.Models
{
    public class TicketCounter
    {
        [Key]
        public int TicketCounterID { get; set; }
        public string TicketCounterName { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
      
    }
}
