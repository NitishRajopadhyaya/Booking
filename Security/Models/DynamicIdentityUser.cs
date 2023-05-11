using System.ComponentModel.DataAnnotations;
using Core.Data.CRUD.Attribute;

namespace Security.Models
{
    public class DynamicIdentityUser : DynamicIdentityUser<int>
    {
        public DynamicIdentityUser() { }

        public DynamicIdentityUser(string userName) : this()
        {
            UserName = userName;
        }
    }

    public class DynamicIdentityUser<TKey> : DynamicIdentityUser<TKey, DynamicIdentityUserClaim<TKey>, DynamicIdentityUserRole<TKey>, DynamicIdentityUserLogin<TKey>>
       where TKey : IEquatable<TKey>
    {
        public DynamicIdentityUser() { }

        public DynamicIdentityUser(string userName) : this()
        {
            UserName = userName;
        }
    }

    public class DynamicIdentityUser<TKey, TUserClaim, TUserRole, TUserLogin> where TKey : IEquatable<TKey>
    {
        public DynamicIdentityUser() { }
        public DynamicIdentityUser(string userName) : this()
        {
            UserName = userName;
        }
        [Key]
        public virtual TKey Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserType { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }

        [IgnoreAll]
        public virtual ICollection<TUserRole> Roles { get; } = new List<TUserRole>();

        [IgnoreAll]
        public virtual ICollection<TUserClaim> Claims { get; } = new List<TUserClaim>();

        [IgnoreAll]
        public virtual ICollection<TUserLogin> Logins { get; } = new List<TUserLogin>();

        public override string ToString()
        {
            return UserName;
        }
    }
}
