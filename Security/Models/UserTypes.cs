using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Security.Models
{
    [Table("IdentityUserRole")]
    public class IdentityUserRole
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
    [Table("UserType")]
    public class UserTypes
    {
        public int Id { get; set; }
        public string UserType { get; set; }
    }
}