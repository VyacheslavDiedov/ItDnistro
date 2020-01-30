using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string EMail { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }

        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}