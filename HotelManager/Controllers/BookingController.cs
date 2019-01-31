using HotelManager.Help;
using HotelManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    public class BookingController : Controller
    {
        [CustomAuth(1, 2)]
        // GET: Booking
        public ActionResult Index()
        {
            Debug.WriteLine(UserSession.CurrentUser.Email);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Booking").Result;

            IndexBookingVM results = new IndexBookingVM();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<IndexBookingVM>(response.Content.ReadAsStringAsync().Result);
            }

            return View(results);
        }
        public JsonResult getJson()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Booking").Result;

            IndexBookingVM results = new IndexBookingVM();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<IndexBookingVM>(response.Content.ReadAsStringAsync().Result);
            }


            return new JsonResult { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult ChangeBookingTime(STBookingGuest bvm)
        {
            var status = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49455/Api/");
                string JsonString = JsonConvert.SerializeObject(bvm);
                StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("Booking/" + bvm.Id, content).Result;
                //Booking result = null;

                if (response.IsSuccessStatusCode)
                {
                    status = true;
                    BlobStockage.WriteLogs($"{DateTime.Now} : Changement sur le booking {bvm.Id} par {UserSession.CurrentUser.LastName} {UserSession.CurrentUser.FirstName}");
                    return new JsonResult { Data = new { status = status } };
                }

                return new JsonResult { Data = new { status = status } };
            }
            catch
            {
                return new JsonResult { Data = new { status = status } };
            }
        }
        //TODO complete the saveBooking and DeleteBooking action...
        [HttpPost]
        public JsonResult SaveBooking(STBookingGuest bvm)
        {
            var status = false;
            try
            {
                if (bvm.Id > 0)
                {

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:49455/Api/");
                    string JsonString = JsonConvert.SerializeObject(bvm);
                    StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("Booking/" + bvm.Id, content).Result;
                    //Booking result = null;

                    if (response.IsSuccessStatusCode)
                    {
                        status = true;
                        BlobStockage.WriteLogs($"{DateTime.Now} : Deleted Employee {bvm.Id}");
                        return new JsonResult { Data = new { status = status } };
                    }

                    return new JsonResult { Data = new { status = status } };

                }
                else
                {
                    try
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:49455/Api/");
                        string JsonString = JsonConvert.SerializeObject(bvm);
                        StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("Booking/", content).Result;
                        //Booking result = null;

                        if (response.IsSuccessStatusCode)
                        {
                            status = true;
                            //WriteLogs($"{DateTime.Now} : Deleted Employee {id}");
                            return new JsonResult { Data = new { status = status } };
                        }

                        return new JsonResult { Data = new { status = status } };
                    }
                    catch
                    {
                        return new JsonResult { Data = new { status = status } };
                    }
                }
            }
            catch
            {
                return new JsonResult { Data = new { status = status } };
            }

        }


        [HttpPost]
        public JsonResult DeleteBooking(int eventID)
        {
            var status = false;

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49455/Api/");
                HttpResponseMessage response = client.GetAsync("Booking/" + eventID).Result;
                Booking result = null;

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<Booking>(response.Content.ReadAsStringAsync().Result);
                    if (result != null)
                    {
                        client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:49455/Api/");
                        response = client.DeleteAsync("Booking/" + result.Id).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            status = false;
                            return new JsonResult { Data = new { status = status } };
                        }
                        else
                        {
                            status = true;
                            //WriteLogs($"{DateTime.Now} : Deleted Employee {id}");
                            return new JsonResult { Data = new { status = status } };
                        }
                    }
                    status = true;
                }

                return new JsonResult { Data = new { status = status } };
            }
            catch
            {
                return new JsonResult { Data = new { status = status } };
            }
        }
    }
}