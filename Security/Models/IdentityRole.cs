using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Security.Models
{
    [Table("IdentityRole")]
    public class IdentityRole : DynamicIdentityRole
    {
        [Key]
        public new long Id { get; set; }
    }
}
