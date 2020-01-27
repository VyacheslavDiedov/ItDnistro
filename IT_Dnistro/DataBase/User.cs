using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User
    {
        [Key]
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
    }
}