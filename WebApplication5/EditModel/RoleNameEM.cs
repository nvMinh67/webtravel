using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.EditModel
{
    public class RoleNameEM
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Role Name is required.")]
        [StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Name { get; set; }    
    }
}
