using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.EditModel
{
    public class CheckOutEM
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Address { get; set; }

        public int id_tour { get; set; }
        public int total_price { get; set; }    

        public int amount_ticket { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Payment { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Note { get; set; }    



    }
}
