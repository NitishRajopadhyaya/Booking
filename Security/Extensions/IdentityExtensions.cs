using System.Security.Claims;
using System.Security.Principal;

namespace Security.Extensions
{

    public static class IdentityExtensions
    {
        public static long GetIdentityUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IdUid");
            // Test for null to avoid issues during local testing
            return (claim != null) ? Convert.ToInt64(claim.Value) : 0;
        }
        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);
            // Test for null to avoid issues during local testing
            return claim.Value;
        }
    }

        //public static class IdentityExtensions
        //{
        //    public static string GetUserName(this IIdentity identity)
        //    {
        //        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);
        //        // Test for null to avoid issues during local testing
        //        return claim.Value;
        //    }
        //    public static bool IsAdmin => ContextResolver.Context.User.IsInRole("Admin");
        //}
        //public static class UserHelper
        //{
        //    public static string UserName
        //    {
        //        get
        //        {
        //            string name = GetClaimsValue(ClaimTypes.Name);
        //            if (string.IsNullOrEmpty(name))
        //                return "guestUser";
        //            return name;

        //        }
        //    }
        //public static string GetName => ((ClaimsIdentity)ContextResolver.Context.User.Identity).FindFirst("name").Value;
        //public static string GetClaimsValue(string key)
        //    {
        //        try
        //        {
        //            var _context = ContextResolver.Context;
        //            if (_context.User.Identity.IsAuthenticated)
        //            {
        //                var identity = (ClaimsIdentity)_context.User.Identity;
        //                IEnumerable<Claim> claims = identity.Claims;
        //                foreach (var claim in claims)
        //                {
        //                    if (claim.Type == key)
        //                        return claim.Value;
        //                }

        //            }
        //            return "";
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }
        //}
    }
