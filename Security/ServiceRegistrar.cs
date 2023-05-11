using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Security.ClaimFactory;
using Security.Extensions;
using IdentityUser = Security.Models.IdentityUser;
using IdentityRole = Security.Models.IdentityRole;
using Core.DI;

namespace Security
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<IdentityUser, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 1;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
            }).UseDapperWithSqlServer()
                .AddClaimsPrincipalFactory
                <ClaimPrincipalFactory<IdentityUser, IdentityRole>>()
                .AddDefaultTokenProviders();
            //serviceCollection.AddDynamicIdentitySever();
        }
    }
}