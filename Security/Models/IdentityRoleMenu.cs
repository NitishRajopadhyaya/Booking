using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Security.Models
{
    public class IdentityRoleMenu<TKey> where TKey : IEquatable<TKey>
    {
        public IdentityRoleMenu()
        {
            Permissions = new HashSet<MenuPermission>();
        }

        public virtual TKey Id { get; set; }

        [Column(Order = 2)]
        public virtual string RoleId { get; set; }

        [Column(Order = 3)]
        public virtual int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public ICollection<MenuPermission> Permissions { get; set; }
    }
}
