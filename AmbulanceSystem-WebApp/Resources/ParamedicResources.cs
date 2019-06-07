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
        public ICollection<OrderResources> FinishedOrders { get; set; }
        public ICollection<OrderResources> FailedOrders { get; set; }
        public AmbulanceCarData AmbulanceCarData { get; set; }

        public ParamedicResources()
        {
            FinishedOrders = new List<OrderResources>();
            FailedOrders = new List<OrderResources>();

        }
    }

    public class OrderResources
    {
        public Guid OrderId { get; set; }
        public DateTime CreationTime { get; set; }
        public FinishedOrderResource FinishedOrderResource { get; set; }
        public FailedOrderResource FailedOrderResource { get; set; }
    }

    public class FailedOrderResource
    {
        public string Reason { get; set; }
    }

    public class FinishedOrderResource
    {
        public string HospitalName { get; set; }
    }
}
