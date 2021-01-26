using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models.Users
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите электронный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
