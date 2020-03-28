using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(35)]
        [Required]
        public string EMail { get; set; }
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }
    }
}
