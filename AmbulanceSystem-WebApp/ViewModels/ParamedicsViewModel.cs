using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.ViewModels
{
    public class ParamedicsViewModel
    {
        public IEnumerable<ParamedicAndCarsResources> AvailableParamedics { get; set; }
        public IEnumerable<ParamedicAndCarsResources> unAvailableParamedics { get; set; }


        public ParamedicsViewModel()
        {
            AvailableParamedics = new List<ParamedicAndCarsResources>();
            unAvailableParamedics=new List<ParamedicAndCarsResources>();
        }
    }
}
