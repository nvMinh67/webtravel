using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Migrations;

namespace WebApplication5.Entity
{
    public class Tour
    {
        public int Id { get; set; } 

        public string Name { get; set; }    

        public string Description { get; set; } 

        public int Price { get; set; }  

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int num_day { get;set; }

        public string id_user { get; set; }
        [ForeignKey("id_user")]
        public ApplicationUser User { get; set; }

        public int Amount { get; set; }

       
       
    }
}
