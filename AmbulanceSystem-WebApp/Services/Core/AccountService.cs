using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;

using AmbulanceSystemWebApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace AmbulanceSystemWebApp.Services.ServicesClasses
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientService _httpClientService;
        public AccountService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async  Task<UserLoginReturn> Login(LoginInfoResources loginInfoResources)
        {

           var responseMessage = await _httpClientService.SendHttpPostRequest(loginInfoResources, "users/login");

           if (string.IsNullOrEmpty(responseMessage))
               return null;

           var UserData = JsonConvert.DeserializeObject<UserLoginReturn>(responseMessage);
           
            

            return UserData;
        }


        //public static SignupAPIResult UploadJsonData<T>(string url, T requestData, string token, string method) where T : new()
        //{
        //    var jsonRequest = JsonConvert.SerializeObject(requestData);
        //    var client = new WebClient()
        //    {
        //        Encoding = Encoding.UTF8,

        //    };
        //    //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        //    //if (!string.IsNullOrEmpty(token))
        //    //    client.Headers.Add("Authorization", "Bearer " + token);
        //    var jsonData = string.Empty;
        //    try
        //    {
        //        jsonData = client.UploadString(url, method, jsonRequest);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new SignupAPIResult() { message = ex.Message, code = 0 };
        //    }

        //    if (string.IsNullOrEmpty(jsonData))
        //        return new SignupAPIResult();
        //    jsonData = jsonData.Replace("[", string.Empty).Replace("]", string.Empty);
        //    var result = JsonConvert.DeserializeObject<SignupAPIResult>(jsonData);
        //    if (result?.code == 0)
        //    {
        //        var result2 = JsonConvert.DeserializeObject<SignupErrorAPIResult>(jsonData);
        //        result = new SignupAPIResult() { code = result2.code, message = result2.message };
        //    }
        //    return result;
        //}
        //public static T DownloadJsonData<T>(string url) where T : new()
        //{
        //    using (var w = new WebClient() { Encoding = Encoding.UTF8 })
        //    {
        //        var jsonData = string.Empty;
        //        try
        //        {
        //            jsonData = w.DownloadString(url);
        //        }
        //        catch (Exception) { }

        //        if (string.IsNullOrEmpty(jsonData))
        //            return new T();
        //        jsonData = jsonData.Replace("[", string.Empty).Replace("]", string.Empty);
        //        return JsonConvert.DeserializeObject<T>(jsonData);
        //    }
        //}
        //public JsonResult ResendCode()
        //{
        //    TempData.Keep("MemberInfo");
        //    var data = (SignUpModel)TempData["MemberInfo"];
        //    if (data.VerificationMethod == "1" || data.VerificationMethod == "2")
        //    {
        //        var memberSignupApi = new MemberSignupAPI();
        //        var result = memberSignupApi.MembershipSelectedMethod(new RegMethodSelectionAPIRequest()
        //        {
        //            membershipId = data.MembershipNo,
        //            sequenceNumber = data.SequenceNo,
        //            phoneType = data.VerificationMethod == "1" ? "first" : "second"
        //        });
        //        if (result.code == 200)
        //        {
        //            data.Token = result.data.ContainsKey("token") ? result.data["token"] : "";
        //            TempData["MemberInfo"] = data;
        //            return Json(true, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        var memberSignupApi = new MemberSignupAPI();
        //        var sendSms = memberSignupApi.SendSmsCodeNationalId(new SendNationalIdSmsAPI()
        //        {
        //            membershipId = data.MembershipNo,
        //            sequenceNumber = data.SequenceNo,
        //            nationalId = data.NationalId,
        //            phoneNumber = data.PhoneNumber
        //        });
        //        if (sendSms.code == 200)
        //        {
        //            data.Token = sendSms.data.ContainsKey("token") ? sendSms.data["token"] : "";
        //            TempData["MemberInfo"] = data;
        //            ShowSuccessMessage();
        //            return Json(true, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return Json(false, JsonRequestBehavior.AllowGet);
        //}
    }
}
