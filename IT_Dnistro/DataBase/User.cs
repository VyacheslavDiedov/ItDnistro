using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        public int Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}