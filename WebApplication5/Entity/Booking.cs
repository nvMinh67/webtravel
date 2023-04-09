using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Entity
{
    public class Booking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }   

        public string Address { get; set; }

        public string Note { get; set; }

        public string Payment { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
