using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Models
{
    [Table("IdentityLogin")]
    public class IdentityLogin
    {
        [Key]
        public long Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }


    }
}