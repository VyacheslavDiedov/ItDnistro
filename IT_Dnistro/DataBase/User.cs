using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        [Key]
        public int Id { get; set; }
    }
}