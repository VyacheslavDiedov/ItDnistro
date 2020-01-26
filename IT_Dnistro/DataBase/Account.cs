using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Account
    { 
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual User User { get; set; }
    }
}
