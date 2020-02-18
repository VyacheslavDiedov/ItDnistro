using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        //public string Country { get; set; }

        //public string City { get; set; }
    }
}