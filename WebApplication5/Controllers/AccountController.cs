using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.EditModel;
using WebApplication5.Entity;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAccountRepository accountRepository, RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager) {
        _accountRepository = accountRepository;
        _roleManager = roleManager;
        _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> createRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> createRole(RoleNameEM model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accountRepository.createRole(model);
            if(result == 500)
            {
                return BadRequest();

            }
            return RedirectToAction("createRole");
            
        }
        [HttpGet]
        public async Task<IActionResult> addRoleToUser()
        {
            var role = await _roleManager.Roles.ToListAsync();
            ViewBag.roles = role;
            var user = await _userManager.Users.ToListAsync();
            ViewBag.users = user;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> addRoleToUser(RoleUserEM model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _accountRepository.addRolesToUser(model);
            if (result == 500)
            {
                return BadRequest();

            }
            return RedirectToAction("addRoleToUser");

        }
    }
}
