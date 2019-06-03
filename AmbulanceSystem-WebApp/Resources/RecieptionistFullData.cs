using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class RecieptionistFullData
    {
        public Guid Id { get; set; }
        public UserData User { get; set; }
        public HospitalBedsData HospitalData { get; set; }
    }

    public class HospitalBedsData
    {
        public HospitalData HospitalData { get; set; }
        public ICollection<BedData> Beds { get; set; }
        public ICollection<DoctorData> Doctors { get; set; }

        public HospitalBedsData()
        {
            Beds=new List<BedData>();
            Doctors=new List<DoctorData>();
        }
    }

    public class DoctorData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DepartmentData DepartmentData { get; set; }
    }

    public class DepartmentData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class BedData
    {
        public Guid Id { get; set; }
        public bool Availability { get; set; }
    }
}
