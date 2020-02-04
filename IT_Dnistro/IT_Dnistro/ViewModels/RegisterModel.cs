using System;
using System.ComponentModel.DataAnnotations;

namespace IT_Dnistro.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
