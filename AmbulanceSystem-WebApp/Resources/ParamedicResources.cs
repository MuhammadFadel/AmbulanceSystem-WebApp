using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class ParamedicResources
    {
        public Guid Id { get; set; }
        public UserData UserData { get; set; }
        public ICollection<FinishedOrderResource> FinishedOrders { get; set; }
        public ICollection<FailedOrderResource> FailedOrders { get; set; }
        public AmbulanceCarData AmbulanceCarData { get; set; }

        public ParamedicResources()
        {
            FinishedOrders = new List<FinishedOrderResource>();
            FailedOrders = new List<FailedOrderResource>();

        }
    }

    public class PatientBriefData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderResources
    {
        public Guid OrderId { get; set; }
        public PatientBriefData Patient { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class FailedOrderResource
    {
        public OrderResources OrderResources { get; set; }
        public string Reason { get; set; }
    }

    public class FinishedOrderResource
    {
        public OrderResources OrderResources { get; set; }
        public string HospitalName { get; set; }
        public ResponsePaymentData PaymentData { get; set; }
    }
}
