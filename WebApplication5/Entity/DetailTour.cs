using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Entity
{
    public class DetailTour
    {
        public int Id { get; set; } 

        public string Title { get; set; }

        public string Description { get; set; }

        public int id_diadiem { get; set; }
        [ForeignKey("id_diadiem")]
        public DIADIEM DIADIEM { get; set; }


        public int id_tour { get; set; }
        [ForeignKey("id_tour")]
        public Tour Tour { get; set;}

    }
}
