using Microsoft.AspNetCore.Identity;

namespace WebApplication5.Entity
{
    public class ApplicationUser : IdentityUser
    {
  
        public string FistName { get; set; }

        public string LastName { get; set; }   
       
    }
}
