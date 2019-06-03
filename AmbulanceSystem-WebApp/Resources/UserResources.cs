using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class UserResources
    {
        public string Username { get; set; }

        public string NationalId { get; set; }
        
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDateTime { get; set; }
        public string BloodType { get; set; }
    }

    public class UserLoginReturn
    {     
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalId { get; set; }

        public string ImageUrl { get; set; }

        public string RoleName { get; set; }
    }
}
