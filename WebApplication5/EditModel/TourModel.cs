using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WebApplication5.Entity;

namespace WebApplication5.EditModel
{
    public class TourModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100)]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Range(0, 999.99)]
        public int Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string id_user { get; set; }
        public  int Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public List<int> id_diadiem { get; set; }

    }
}
