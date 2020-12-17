using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MOTChecker.Models;
using Newtonsoft.Json;

namespace MOTChecker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //GET /Search/Reg
        public ActionResult Search(String reg)
        {
            
            if (!String.IsNullOrWhiteSpace(reg))
            {
                var _vehicle = new KeyValuePair<string,Vehicle>();
                _vehicle = GetVehicleAsync(reg);
                if(_vehicle.Value != null)
                    return PartialView("_SearchResult",_vehicle.Value);
                
                ViewBag.ErrorMessage = _vehicle.Key;
                ViewBag.Registration = reg;
                return PartialView("_NotFound");
            }
            
            return Content("");
            

        }

        public KeyValuePair<string,Vehicle> GetVehicleAsync(string reg_number)
        {
            Vehicle _vehicle = null;
            String sMessage="" ;
            int _errorCode=0;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests");
                client.DefaultRequestHeaders.Add("x-api-key", "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = client.GetAsync("?registration=" + reg_number).Result;
                if (response.IsSuccessStatusCode)
                {
                     _errorCode = (int)response.StatusCode;
                    var reply = response.Content.ReadAsStringAsync();
                    List<Vehicle> l_vehicle  = JsonConvert.DeserializeObject<List<Vehicle>>(reply.Result.ToString());
                    _vehicle = l_vehicle[0];
                }
                else
                {
                    _errorCode = (int)response.StatusCode;
                    sMessage = _errorCode.ToString() + ": " + response.ReasonPhrase;
                }
            }
            KeyValuePair<string,Vehicle> _result  = new KeyValuePair<string, Vehicle>(sMessage,_vehicle);
            return _result;
        }


    }
}