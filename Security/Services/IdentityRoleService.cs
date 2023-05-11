using Core.Data.CRUD;
using Security.Models;

namespace Security.Services
{
    public class IdentityRoleService : IIdentityRoleService
    {
        public CrudService<IdentityRole> RoleService { get; set; } = new CrudService<IdentityRole>();
        public CrudService<UserTypes> UserTypeCrudService { get; set; } = new CrudService<UserTypes>();
    }
}
