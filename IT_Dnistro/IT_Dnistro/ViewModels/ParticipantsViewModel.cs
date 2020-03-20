using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Dnistro.ViewModels
{
    public class ParticipantsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public int TourTypeId { get; set; }
        public string TourName { get; set; }
    }
}
