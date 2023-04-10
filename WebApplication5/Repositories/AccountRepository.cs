using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.EditModel;
using WebApplication5.Entity;

namespace WebApplication5.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private MyDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(MyDbContext context,RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager) {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<int> createRole(RoleNameEM model)
        {
            var roleExist = await _roleManager.RoleExistsAsync(model.Name);
            if(roleExist)
            {
                return 500;

            }
            var role = new IdentityRole();
            role.Name = model.Name;
            await _roleManager.CreateAsync(role);

            return 200;
           
        }
        public async Task<int> addRolesToUser (RoleUserEM model)
        {
            var user = await _userManager.FindByIdAsync(model.id_user);
            if(user == null)
            {
                return 500;

            }
            foreach(var role in model.roles) {
                await _userManager.AddToRoleAsync(user, role);
            }
            return 200;
        }
    }
}
