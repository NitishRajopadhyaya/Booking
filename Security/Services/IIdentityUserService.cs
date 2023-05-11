using Core.Data.CRUD;
using Security.Models;

namespace Security.Services
{
    public interface IIdentityUserService
    {
        CrudService<IdentityUser> UserService { get; set; }
        CrudService<IdentityUserClaim> ClaimService { get; set; }
        CrudService<IdentityUserRole> UserRoleService { get; set; }
        CrudService<IdentityLogin> LoginService { get; set; }
        Task<List<string>> GetUserRoleNamesById(long userIdentityUserId);
    }
}
