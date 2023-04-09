using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModel
{
    public class Login
    {
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

        public bool RememberMe { get; set; }
    }
}
