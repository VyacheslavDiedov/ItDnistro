using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string TourName { get; set; }

        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }

        [Required]
        public DateTime TourDate { get; set; }

        [Required]
        public int TourLength { get; set; }
    }
}