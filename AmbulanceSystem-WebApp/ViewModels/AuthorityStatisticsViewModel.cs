using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.ViewModels
{
    public class AuthorityStatisticsViewModel
    {
        public int AvailableParamedicCount { get; set; }
        public int unAvailableParamedicCount { get; set; }
        public int FinishedOrders { get; set; }
        public int FailedOrders { get; set; }
    }
}
