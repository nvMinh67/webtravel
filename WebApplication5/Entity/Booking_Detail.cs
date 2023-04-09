using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Entity
{
    public class Booking_Detail
    {
        public int Id { get; set; } 

        public int id_booking { get; set; }
        [ForeignKey("id_booking")]
        public Booking booking { get; set; }    

        public int amount_ticket { get; set; }
        
        public int total_price { get; set;}

        public Status Status { get; set; }
        public int id_tour { get; set; }
        [ForeignKey("id_tour")]
        public Tour Tour { get; set; }  
        public DateTime CreateAt { get; set; } = DateTime.Now;

        
    }
}
