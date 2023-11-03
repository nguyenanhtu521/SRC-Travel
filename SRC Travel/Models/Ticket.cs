using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC_Travel.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public int CustomerID { get; set; }
        [ForeignKey(nameof(BusID))]

        public int BusID { get; set; }
        [ForeignKey(nameof(UserID))]
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime TravelDate { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public string? Flag { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Buses? Buses { get; set; }
        public virtual User? User { get; set; }
    }
}
