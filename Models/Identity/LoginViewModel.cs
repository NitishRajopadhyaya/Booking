using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        = string.Empty;
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }
}
