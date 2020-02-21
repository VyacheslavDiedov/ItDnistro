using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class TourType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string TourTypeName { get; set; }
        public string TourTypeDescription { get; set; }
    }
}