using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class ReportResources
    {

        public Guid Id { get; set; }
        public Guid HospitalId { get; set; }
        public Guid PatientId { get; set; }
        public string DiseaseName { get; set; }
        public string Description { get; set; }
        public bool IsChronicDisease { get; set; }

    }
}
