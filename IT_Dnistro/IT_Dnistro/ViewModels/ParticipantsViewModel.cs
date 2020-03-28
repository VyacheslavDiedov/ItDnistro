using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Dnistro.ViewModels
{
    public class ParticipantsViewModel
    {
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
        public string TourName { get; set; }
    }
}
