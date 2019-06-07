using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class ReportCreationResources
    {

        [Required(ErrorMessage = "Hospital Id is Required")]
        public Guid HospitalId { get; set; }

        [Required(ErrorMessage = "Patient Id is Required")]
        public Guid PatientId { get; set; }

        [Required(ErrorMessage = "Disease Name is Required")]
        public string DiseaseName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Chronic Disease status is Required")]
        public bool IsChronicDisease { get; set; }

    }
}
