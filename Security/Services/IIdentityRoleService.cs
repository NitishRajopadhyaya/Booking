using Core.Data.CRUD;
using Security.Models;

namespace Security.Services
{
    public interface IIdentityRoleService
    {
        CrudService<IdentityRole> RoleService { get; set; }
        CrudService<UserTypes> UserTypeCrudService { get; set; }
    }
}
