using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Models
{
    public class HospitalDashboardViewModel
    {
        public int PatientCounter { get; set; }
        public int AvailableBeds { get; set; }
        public int UsedBeds { get; set; }
    }
}
