using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class PatientFullData
    {
        public Guid Id { get; set; }

        public UserData User { get; set; }

        public DateTime Birthdate { get; set; }

        public string BloodType { get; set; }

        public string History { get; set; }


        public ICollection<ReportTuble> Reports { get; set; }


        public ICollection<PatientRelativesData> PatientRelatives { get; set; }
        public ICollection<RequestData> PatientRequests { get; set; }

        public PatientFullData()
        {
            PatientRelatives = new List<PatientRelativesData>();
            PatientRequests = new List<RequestData>();
            Reports = new List<ReportTuble>();
        }
    }

    public class PatientRelativesData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RequestData
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
    }



    public class HospitalData
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }

    public class UserData
    {

        public string Username { get; set; }

        public string Email { get; set; }


        public string PhoneNumber { get; set; }


        public string NationalId { get; set; }


        public string ImageUrl { get; set; }
    }
}
