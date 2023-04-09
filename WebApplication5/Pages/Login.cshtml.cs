using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Entity;
using WebApplication5.ViewModel;

namespace WebApplication5.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }
        public LoginModel(SignInManager<ApplicationUser> signInMannager) { 
        this.signInManager = signInMannager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var identity = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if(identity.Succeeded)
                {
                 
                        return RedirectToPage("Index");
                   

                }
                ModelState.AddModelError("", "UserName or Password Incorrect");
            }
            return Page();
        }
    }
}
