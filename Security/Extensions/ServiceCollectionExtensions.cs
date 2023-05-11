using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.ClaimFactory;
using Security.Cryptography;
using Security.Models;
using Security.Services;
using Security.Stores;
using System;

namespace Security.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection ConfigureIdentityCryptography(this IServiceCollection services, IConfigurationSection configuration)
        //{
        //    services.Configure<AESKeys>(configuration);
        //    services.AddSingleton<EncryptionHelper>();
        //    return services;
        //}

        public static IdentityBuilder UseDapperWithSqlServer(this IdentityBuilder builder)
        {

            UseIdentityStores(builder.Services, builder.UserType, builder.RoleType);

            return builder;
        }

        public static IdentityBuilder UseDapperWithSqlServer<TKey>(this IdentityBuilder builder)
        {

            UseIdentityStores(builder.Services, builder.UserType, builder.RoleType, typeof(TKey));

            return builder;
        }


        public static IdentityBuilder UseDapperWithSqlServer<TKey, TUserRole, TRoleClaim>(this IdentityBuilder builder)
        {

            UseIdentityStores(builder.Services, builder.UserType, builder.RoleType, typeof(TKey), typeof(TUserRole), typeof(TRoleClaim));

            return builder;
        }


        private static void UseIdentityStores(IServiceCollection services, Type userType, Type roleType, Type keyType = null, Type userRoleType = null, Type roleClaimType = null, Type userClaimType = null, Type userLoginType = null)
        {
            keyType ??= typeof(int);
            userRoleType ??= typeof(DynamicIdentityUserRole<>).MakeGenericType(keyType);
            roleClaimType ??= typeof(DynamicIdentityRoleClaim<>).MakeGenericType(keyType);
            userClaimType ??= typeof(DynamicIdentityUserClaim<>).MakeGenericType(keyType);
            userLoginType ??= typeof(DynamicIdentityUserLogin<>).MakeGenericType(keyType);

            var userStoreType = typeof(UserStore<,,,,,,>).MakeGenericType(userType, keyType, userRoleType, roleClaimType,
                userClaimType, userLoginType, roleType);
            var roleStoreType = typeof(RoleStore<,,,>).MakeGenericType(roleType, keyType, userRoleType, roleClaimType);

            services.AddScoped<IIdentityRoleService, IdentityRoleService>();
            services.AddScoped<IIdentityUserService, IdentityUserService>();
            services.AddScoped(typeof(IUserStore<>).MakeGenericType(userType), userStoreType);
            services.AddScoped(typeof(IRoleStore<>).MakeGenericType(roleType), roleStoreType);

        }

        public static IServiceCollection AddIdentityServerUserClaimsPrincipalFactory<TUser, TRole>(this IServiceCollection services)
          where TUser : class
          where TRole : class
        {
            return services.AddTransient<IUserClaimsPrincipalFactory<TUser>, ClaimPrincipalFactory<TUser, TRole>>();
        }


    }
}
