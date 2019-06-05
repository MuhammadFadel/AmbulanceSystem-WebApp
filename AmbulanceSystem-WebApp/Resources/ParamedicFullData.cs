using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class ParamedicFullData
    {
        public Guid Id { get; set; }
        public UserData UserData { get; set; }
        public AmbulanceCarData AmbulanceCarData { get; set; }
    }

    public class AmbulanceCarData
    {
        public Guid Id { get; set; }
        public string CarNumber { get; set; }
    }
}
