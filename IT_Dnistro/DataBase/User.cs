using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}