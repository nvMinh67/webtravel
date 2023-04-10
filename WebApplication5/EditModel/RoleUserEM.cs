using Microsoft.Build.Framework;
using WebApplication5.Entity;

namespace WebApplication5.EditModel
{
    public class RoleUserEM
    {
        [Required]
        public string id_user { get; set; }
        [Required] 
        public List<string> roles { get; set; }
    }
}
