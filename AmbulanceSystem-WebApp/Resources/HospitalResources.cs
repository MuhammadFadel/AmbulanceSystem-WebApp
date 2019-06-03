using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class HospitalResources
    {
        public  Guid HospitalId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string Specialization { get; set; }
    }
}
