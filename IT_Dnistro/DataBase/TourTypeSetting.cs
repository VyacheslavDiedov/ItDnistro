using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class TourTypeSetting
    {
        [Key]
        public int Id { get; set; }
        public virtual TourType Type { get; set; }
        [Required]
        public string BackColor { get; set; }
        [Required]
        public string BackgroundImageLink { get; set; }
    }
}