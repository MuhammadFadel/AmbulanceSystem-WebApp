using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class HospitalStatisticsViewModel
    {
        public int AvailableBedsCount { get; set; }
        public int UmAvailableBedsCount { get; set; }
        public int PatientsCount { get; set; }
    }
}
