using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DataBase
{
    public class UserTour
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }

        [Required]
        public string HowFoundUs { get; set; }
    }
}
