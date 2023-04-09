using Microsoft.AspNetCore.Http.Metadata;

namespace WebApplication5.ViewModel
{
    public class ModelCreateDiaDiem
    {
        public string TENDIADIEM { get; set; }
        public string DIACHI { get; set; }
        public string MOTA { get; set; }
        public string MAP { get; set; }

        public List<IFromBodyMetadata> fromBodyMetadata { get; set; }
    }
}
