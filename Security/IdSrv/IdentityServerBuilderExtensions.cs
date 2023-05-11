using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Security.IdSrv
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAspNetIdentity<TUser>(this IIdentityServerBuilder builder)
            where TUser : class
        {
            return builder.AddAspNetIdentity<TUser>("Identity.Application");
        }

        public static IIdentityServerBuilder AddAspNetIdentity<TUser>(this IIdentityServerBuilder builder, string authenticationScheme)
            where TUser : class
        {
           

            return builder;
        }
    }
}
