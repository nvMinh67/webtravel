using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Entity
{
    public class DIADIEM
    {

        public int ID { get; set; }
        public string TENDIADIEM { get; set; }
        public string DIACHI { get; set; }
        public string MOTA { get; set; }
        public string MAP { get; set; }
        public ICollection<image_DIADIEM> image_DIADIEMs { get; set; }
     
    }
}
