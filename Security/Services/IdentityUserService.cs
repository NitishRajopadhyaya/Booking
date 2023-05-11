using Core.Data;
using Core.Data.CRUD;
using Dapper;
using Security.Models;
using System.Data.Common;

namespace Security.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        public CrudService<IdentityUser> UserService { get; set; } = new CrudService<IdentityUser>();
        public CrudService<IdentityUserClaim> ClaimService { get; set; } = new CrudService<IdentityUserClaim>();
        public CrudService<IdentityUserRole> UserRoleService { get; set; } = new CrudService<IdentityUserRole>();
        public CrudService<IdentityLogin> LoginService { get; set; } = new CrudService<IdentityLogin>();

        public async Task<List<string>> GetUserRoleNamesById(long userIdentityUserId)
        {
            var dbFactory = DbFactoryProvider.GetFactory();
            using (var db = (DbConnection)dbFactory.GetConnection())
            {
                await db.OpenAsync();
                var roles = await db.QueryAsync<string>("select name from identityrole as r inner join IdentityUserRole as ir on r.id=ir.roleId where ir.UserId = @UserId;", new { UserId = userIdentityUserId });
                return roles.ToList();


            }
        }
    }
}
