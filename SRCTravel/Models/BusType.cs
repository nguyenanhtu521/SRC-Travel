using System.ComponentModel.DataAnnotations;

namespace SRCTravel.Models
{
    public class BusType
    {
        [Key]
        public int BusTypeID { get; set; }
        public string BusTypeName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
       
    }
}
