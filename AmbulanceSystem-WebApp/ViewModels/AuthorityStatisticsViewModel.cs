using AmbulanceSystem_WebApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.ViewModels
{
    public class AuthorityStatisticsViewModel
    {
        public IEnumerable<ResponseOrderData> Notifications { get; set; }
        public int AvailableParamedicCount { get; set; }
        public int unAvailableParamedicCount { get; set; }
        public int FinishedOrders { get; set; }
        public int FailedOrders { get; set; }

        public AuthorityStatisticsViewModel()
        {
            Notifications = new List<ResponseOrderData>();
        }
    }
}
