using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class BedResource
    {
        public List<AvailableBeds> AvailableBeds { get; set; }
        public List<UnAvailableBeds> UnAvailableBeds { get; set; }

        public BedResource()
        {
            AvailableBeds = new List<AvailableBeds>();
            UnAvailableBeds = new List<UnAvailableBeds>();
        }
    }

    public class UnAvailableBeds
    {
        public Guid id { get; set; }
    }

    public class AvailableBeds
    {
        public Guid id { get; set; }
    }
}
