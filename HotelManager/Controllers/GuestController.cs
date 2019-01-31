using HotelManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Guest").Result;

            List<Guest> results = new List<Guest>();
            
            if(response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<List<Guest>>(response.Content.ReadAsStringAsync().Result);
            }


            return View(results);
        }
    }
}