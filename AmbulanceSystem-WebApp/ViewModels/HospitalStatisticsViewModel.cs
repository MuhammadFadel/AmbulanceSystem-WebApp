using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class HospitalStatisticsViewModel
    {
        public IEnumerable<PatientFullData> Notifications { get; set; }
        public int AvailableBedsCount { get; set; }
        public int UmAvailableBedsCount { get; set; }
        public int PatientsCount { get; set; }

        public HospitalStatisticsViewModel()
        {
            Notifications = new List<PatientFullData>();
        }
    }
}
