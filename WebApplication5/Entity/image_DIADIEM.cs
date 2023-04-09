
using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Entity
{
    public class image_DIADIEM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int id_DIADIEM { get; set; }
        public DIADIEM dIADIEM { get; set; }
    }
}
