using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string Interests { get; set; }
        public string HowFoundUs { get; set; }
    }
}