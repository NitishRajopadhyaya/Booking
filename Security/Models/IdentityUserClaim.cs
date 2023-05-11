using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Security.Models
{
    [Table("IdentityUserClaim")]
    public class IdentityUserClaim
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}