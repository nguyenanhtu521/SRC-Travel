using System.ComponentModel.DataAnnotations;

namespace SRC_Travel.Models
{
    public class AgeGroup
    {
        [Key]
        public int AgeGroupID { get; set; }
        public string AgeGroupName { get; set; }    
        public double Benefit { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public string Flag { get; set; }

    }
}
