using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class ReportTuble
    {
        public Guid ReportId { get; set; }
        public string PatientName { get; set; }
        public string HospitalName { get; set; }
        public string DiseaseName { get; set; }
        public string Description { get; set; }
        public bool IsChronicDisease { get; set; }
    }
}
