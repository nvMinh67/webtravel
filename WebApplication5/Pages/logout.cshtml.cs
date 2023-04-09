using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Entity;

namespace WebApplication5.Pages
{
    public class logoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public logoutModel(SignInManager<ApplicationUser> sighInManager) {
        this.signInManager = sighInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Login");

        }
        public IActionResult OnPostDontLogoutAsync()
        { 

            return RedirectToPage("Index");

        }


    }
}
