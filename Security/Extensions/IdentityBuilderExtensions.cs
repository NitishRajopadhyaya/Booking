using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Security.IdentityConfig;
using Security.IdSrv;
using Security.Models;

namespace Security.Extensions
{
    public static class IdentityBuilderExtensions
    {

        public static void AddDynamicIdentitySever(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentityServer()
          .AddDeveloperSigningCredential()
          .AddInMemoryPersistedGrants()
          .AddInMemoryIdentityResources(Resources.GetIdentityResources())
          .AddInMemoryApiResources(Resources.GetApiResources())
          .AddInMemoryClients(Clients.Get())
          .AddAspNetIdentity<IdentityUser>();
        }
    }
}