using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class OrdersAndAuthoritiesResources
    {
    }

    //Hold All Data about Request
    public class ResponseRequestData
    {
        public Guid Id { get; set; }
        public double Langitude { get; set; }
        public double Latitude { get; set; }            
        public DateTime CreationTime { get; set; }
        public ResponsePatientData Patient { get; set; }
    }
    //Hold All Data about Patient
    public class ResponsePatientData
    {        
        public Guid Id { get; set; }
        public string Username { get; set; }               
        public string Email { get; set; }
        public string PhoneNumber { get; set; }        
        public string NationalId { get; set; }                
        public DateTime Birthdate { get; set; }        
        public string BloodType { get; set; }
        public string History { get; set; }       
    }
    //Hold All Data about Paramedic
    public class ResponseParamedicData
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public ResponseAmbulanceCarData AmbulanceCar { get; set; }
    }
    //Hold All Data about Ambulance
    public class ResponseAmbulanceCarData
    {
        public Guid Id { get; set; }
        public string CarNumber { get; set; }
    }    

    public class ResponseOrderData
    {        
        public Guid Id { get; set; }                
        public ResponseRequestData Request { get; set; }                       
        public ResponseParamedicData Paramedic { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class ResponseHospitalData
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public double Langitude { get; set; }        
        public double Latitude { get; set; }        
    }
    public class ResponsePaymentData
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
    public class ResponseFailReasonData
    {       
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
    public class ResponseFinishedOrder
    {
        public Guid Id { get; set; }        
        public ResponseHospitalData Hospital { get; set; }        
        public ResponsePaymentData Payment { get; set; }        
        public DateTime ArrivalTime { get; set; }
        public ResponseOrderData OrderData { get; set; }

    }
    public class ResponseFailedOrder
    {
        public Guid Id { get; set; }
        public ResponseOrderData OrderData { get; set; }
        public ResponseFailReasonData FailReason { get; set; }
    }
    
    public class ResponseAllOrders
    {
        public IEnumerable<ResponseFinishedOrder> FinishedOrders { get; set; }
        public IEnumerable<ResponseFailedOrder> FailedOrders { get; set; }
        public IEnumerable<ResponseOrderData> UnderProcessingOrders { get; set; }

        public ResponseAllOrders()
        {
            FinishedOrders = new List<ResponseFinishedOrder>();
            FailedOrders = new List<ResponseFailedOrder>();
            UnderProcessingOrders = new List<ResponseOrderData>();
        }
    }

}
