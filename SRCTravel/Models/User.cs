using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCTravel.Models
{
    public class User : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Address { get; set; }
        public string Qualification { get; set; }
       
        //[ForeignKey(nameof(TicketCounterID))]
        //public int TicketCounterID { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
   
        public virtual TicketCounter? TicketCounter { get; set; }
    }
}
