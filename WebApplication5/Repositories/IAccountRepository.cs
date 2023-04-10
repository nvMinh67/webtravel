using Microsoft.AspNetCore.Mvc;
using WebApplication5.EditModel;

namespace WebApplication5.Repositories
{
    public interface IAccountRepository
    {
        Task<int> createRole(RoleNameEM model);
        Task<int> addRolesToUser(RoleUserEM model);
    }
}
