using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage ="Email Address Is Required")]
        [EmailAddress(ErrorMessage ="Should be valid Email Address Pattern")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class ConfirmNewPassword
    {
        [HiddenInput]
        [Required]
        public Guid LinkId { get; set; }

        [Required(ErrorMessage ="Password Field Is Required")]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Field Is Required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
