using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class PatientRelativesResources
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        
        public string PhoneNumber { get; set; }

        public bool IsVerified { get; set; }
    }
}
