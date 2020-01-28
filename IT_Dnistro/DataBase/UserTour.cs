using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class UserTour
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
        public string HowFoundUs { get; set; }
    }
}
