using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Security.Models
{
    [Table("IdentityUser")]
    public class IdentityUser : DynamicIdentityUser
    {

    }
}
