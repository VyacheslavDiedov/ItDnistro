using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase
{
    public class UserAdditionalInfo 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual IdentityUser User { get; set; }
        
        [Required]
        public int Gender { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
