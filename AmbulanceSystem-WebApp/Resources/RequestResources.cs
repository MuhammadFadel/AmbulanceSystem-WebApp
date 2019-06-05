using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class RequestResources
    {
        public Guid Id { get; set; }
        public double Langitude { get; set; }
        public double Latitude { get; set; }
        public Guid PatientId { get; set; }
        public string Address { get; set; }
        
    }
}
