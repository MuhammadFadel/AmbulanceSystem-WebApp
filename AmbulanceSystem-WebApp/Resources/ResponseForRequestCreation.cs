﻿using System;
using System.Collections.Generic;
using System.Text;


namespace AmbulanceSystem_WebApp.Model
{
    public class ResponseForRequestCreation
    {
        public string ParamedicName { get; set; }
        
        public string AuthorityLocation { get; set; }
        
        public double TimeInSeconds { get; set; }
        public double Distance { get; set; }
    }
}
