using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.EditModel
{
    public class ContactDetailEM
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Phone]
        public string Phone { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Address { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
       public string Message { get; set; }
        public int id_tour { get; set; }

        public int amount_ticket { get; set; }

    }
}
