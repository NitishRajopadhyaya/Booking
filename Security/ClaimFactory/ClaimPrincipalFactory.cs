using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Security.ClaimFactory
{
    public class ClaimPrincipalFactory<TUser, TRole> : UserClaimsPrincipalFactory<TUser, TRole>
         where TUser : class
        where TRole : class
    {
        public ClaimPrincipalFactory(UserManager<TUser> userManager, RoleManager<TRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {

        }
        private async Task<ClaimsIdentity> GenerateCustomClaimsAsync(TUser user)
        {
            UserClaimsPrincipalFactory<TUser> principalFactory = this;
            string userId = await principalFactory.UserManager.GetUserIdAsync(user);
            string userNameAsync = await principalFactory.UserManager.GetUserNameAsync(user);
            ClaimsIdentity id = new ClaimsIdentity("Identity.Application", principalFactory.Options.ClaimsIdentity.UserNameClaimType, principalFactory.Options.ClaimsIdentity.RoleClaimType);
            id.AddClaim(new Claim(principalFactory.Options.ClaimsIdentity.UserIdClaimType, userId));
            id.AddClaim(new Claim(principalFactory.Options.ClaimsIdentity.UserNameClaimType, userNameAsync));
            ClaimsIdentity claimsIdentity;
            if (principalFactory.UserManager.SupportsUserSecurityStamp)
            {
                claimsIdentity = id;
                string type = principalFactory.Options.ClaimsIdentity.SecurityStampClaimType;
                claimsIdentity.AddClaim(new Claim(type, await principalFactory.UserManager.GetSecurityStampAsync(user)));
                claimsIdentity = (ClaimsIdentity)null;
                type = (string)null;
            }
           
            if (principalFactory.UserManager.SupportsUserClaim)
            {
                claimsIdentity = id;
                claimsIdentity.AddClaims((IEnumerable<Claim>)await principalFactory.UserManager.GetClaimsAsync(user));
                claimsIdentity = (ClaimsIdentity)null;
            }
            return id;
        }
        public async override Task<ClaimsPrincipal> CreateAsync(TUser user)
        {
            try
            {
                var principal = new ClaimsPrincipal();
                try
                {
                    principal = await base.CreateAsync(user);
                }
                catch (Exception)
                {
                    principal = new ClaimsPrincipal((IIdentity)await GenerateCustomClaimsAsync(user));
                }

                var identity = principal.Identities.First();
                if (!identity.HasClaim(x => x.Type == JwtClaimTypes.Subject))
                {
                    var sub = await UserManager.GetUserIdAsync(user);
                    identity.AddClaim(new Claim(JwtClaimTypes.Subject, sub));
                }
                var username = await UserManager.GetUserNameAsync(user);
                var usernameClaim = identity.FindFirst(claim => claim.Type == UserManager.Options.ClaimsIdentity.UserNameClaimType && claim.Value == username);

                if (usernameClaim != null)
                {
                    identity.RemoveClaim(usernameClaim);
                    identity.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, username));
                    var userId = await UserManager.GetUserIdAsync(user);
                    identity.AddClaim(new Claim("IdUid", userId));
                }
                if (!identity.HasClaim(x => x.Type == JwtClaimTypes.Name))
                {
                    identity.AddClaim(new Claim(JwtClaimTypes.Name, username));
                }

                if (UserManager.SupportsUserEmail)
                {
                    var email = await UserManager.GetEmailAsync(user);
                    if (!String.IsNullOrWhiteSpace(email))
                    {
                        identity.AddClaims(new[]
                        {
                        new Claim(JwtClaimTypes.Email, email),
                        new Claim(JwtClaimTypes.EmailVerified,
                            await UserManager.IsEmailConfirmedAsync(user) ? "true" : "false", ClaimValueTypes.Boolean)
                    });
                    }
                }
                return principal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
