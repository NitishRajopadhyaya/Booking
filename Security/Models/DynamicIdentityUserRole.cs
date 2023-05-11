using System;

namespace Security.Models
{
    public class DynamicIdentityUserRole<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey UserId { get; set; }
        public virtual TKey RoleId { get; set; }
    }
}
