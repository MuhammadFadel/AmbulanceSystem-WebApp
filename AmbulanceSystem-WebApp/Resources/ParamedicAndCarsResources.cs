using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Resources
{
    public class ParamedicAndCarsResources
    {
        public Guid Id { get; set; }
        public DateTime LastOrderTime { get; set; }        
        public string Avalaibility { get; set; }
        public UserData UserData { get; set; }
        public AmbulanceCarInfo AmbulanceCarInfo { get; set; }

    }

   

    public class AmbulanceCarInfo
    {
        public string CarNumber { get; set; }
        
        public bool IsAvailable { get; set; }
        
        public bool IsInMaintinance { get; set; }
    }
}
