using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class PatientFullData
    {
        public Guid Id { get; set; }

        
        
       
        public UserData User { get; set; }

        
        public DateTime Birthdate { get; set; }

        
        public string BloodType { get; set; }

        

        public string History { get; set; }

       
        public ICollection<ReportData> Reports { get; set; }

        
        public ICollection<PatientRelativesData> PatientRelatives { get; set; }
        public ICollection<RequestData> PatientRequests { get; set; }

        public PatientFullData()
        {
            PatientRelatives = new List<PatientRelativesData>();
            PatientRequests=new List<RequestData>();
            Reports=new List<ReportData>();
        }
    }

    public class PatientRelativesData
    {
        public Guid id { get; set; }
        public string  Name { get; set; }
    }

    public class RequestData
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class ReportData
    {
        public Guid Id { get; set; }
        public HospitalData HospitalData { get; set; }

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
