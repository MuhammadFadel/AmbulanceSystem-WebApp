using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class LoginInfoResources
    {
        [Required(ErrorMessage = "Email Field Is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Should Be Email Address" )]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Field Is Required")]
        [DataType(DataType.Password, ErrorMessage = "Should Be Your Email Password" )]
        public string Password { get; set; }        
    }

    public class LogoutInfoResources
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
    }
}
