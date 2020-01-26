using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Interests { get; set; }
    }
}