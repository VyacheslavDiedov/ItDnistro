using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IT_Dnistro.ViewModels
{
    public class AddParticipantViewModel
    {
        public IdentityUser User { get; set; }
        public int TourId { get; set; }
        public string HowFoundUs { get; set; }
    }
}
