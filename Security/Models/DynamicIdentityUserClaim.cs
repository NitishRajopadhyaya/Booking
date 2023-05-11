using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Security.Models
{
    public class DynamicIdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        public virtual int Id { get; set; }
        public virtual TKey UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }

        public virtual Claim ToClaim() => new Claim(ClaimType, ClaimValue);

        public virtual void InitializeFromClaim(Claim claim)
        {
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }
    }
}
