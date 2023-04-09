using Microsoft.AspNetCore.Http.Metadata;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.EditModel
{
    public class LocationModel
    {
        [Required]
        public string TENDIADIEM { get; set; }
        [Required]
        public string DIACHI { get; set; }
        [Required]
        public string MOTA { get; set; }
        [Required]
        public string MAP { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
