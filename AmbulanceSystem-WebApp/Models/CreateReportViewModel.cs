using AmbulanceSystem_WebApp.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Models
{
    public class CreateReportViewModel
    {
        [HiddenInput]
        public Guid HospitalId { get; set; }

        [Required(ErrorMessage = "Patient Id is Required")]
        public Guid PatientId { get; set; }

        public IEnumerable<PatientFullData> PatientsList { get; set; }

        [Required(ErrorMessage = "Disease Name is Required")]
        public string DiseaseName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Chronic Disease status is Required")]
        public bool IsChronicDisease { get; set; }
    }
    
}
