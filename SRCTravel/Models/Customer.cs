using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCTravel.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [ForeignKey(nameof(AgeGroupID))]
        public int AgeGroupID { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        

        public virtual AgeGroup? AgeGroup { get; set; }
    }
}
