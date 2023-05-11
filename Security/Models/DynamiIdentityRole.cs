using System;
using System.Collections.Generic;

namespace Security.Models
{

    public class DynamicIdentityRole : DynamicIdentityRole<int>
    {

        public DynamicIdentityRole() { }
        public DynamicIdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class DynamicIdentityRole<TKey> : DynamicIdentityRole<TKey, DynamicIdentityUserRole<TKey>, DynamicIdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        public DynamicIdentityRole() { }
        public DynamicIdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class DynamicIdentityRole<TKey, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TUserRole : DynamicIdentityUserRole<TKey>
    {
        #region Properties

        public virtual ICollection<TUserRole> Users { get; } = new List<TUserRole>();
        public virtual ICollection<TRoleClaim> Claims { get; } = new List<TRoleClaim>();

        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }

        #endregion

        #region Constructors

        public DynamicIdentityRole() { }

        public DynamicIdentityRole(string roleName) : this()
        {
            Name = roleName;
        }

        #endregion
    }
}
