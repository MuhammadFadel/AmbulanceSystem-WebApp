using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class ParamedicOrderNotification
    {
        public string PatientName { get; set; }
        public List<ReportTuble> PatientReports { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public ParamedicOrderNotification()
        {
            PatientReports= new List<ReportTuble>();
        }

    }
}
