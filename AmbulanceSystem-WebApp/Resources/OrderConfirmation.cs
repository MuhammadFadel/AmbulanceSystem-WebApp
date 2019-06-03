using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem.Resources
{
    public class OrderConfirmation
    {
        public Boolean OrderStatus { get; set; }
        public Guid OrderFailureReasonId { get; set; }

        public Guid HospitalId { get; set; }
        public Guid PaymentId { get; set; }

        public DateTime ArrivalTime { get; set; }
        public Guid OrderId { get; set; }

    }
}
