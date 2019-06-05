using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class ParamedicResources
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderResources> Orders { get; set; }
    }

    public class OrderResources
    {
        public Guid OrderId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
