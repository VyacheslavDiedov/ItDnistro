using Microsoft.AspNetCore.Identity;

namespace IT_Dnistro.Models
{
    public class Admin : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
