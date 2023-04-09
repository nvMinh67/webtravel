using Microsoft.Build.Framework;

namespace WebApplication5.EditModel
{
    public class BookingEM
    {
        [Required]
        public int id_tour { get; set; }
        [Required]
        public int amount_ticket { get; set; }
    }
}
