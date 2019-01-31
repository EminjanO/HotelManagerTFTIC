using HotelManager.Help;
using HotelManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    public class UserController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {            
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Index(UserViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}

            try
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:49455/Api/");
                    string jsonString = JsonConvert.SerializeObject(viewModel);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    User results = new User();

                    HttpResponseMessage response = client.PostAsync("Login/", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        //WriteLogs($"{DateTime.Now} : Inserted {jsonString}");
                        //return RedirectToAction("Index");
                        results = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                        if (results != null)
                        {
                            //Session["User"] = myUser;
                            UserSession.CurrentUser = results;
                            return RedirectToAction("Index", "booking");
                        }

                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index"); 
                }
            }
            catch
            {
                return View();
            }
        }
        [CustomAuth(1)]
        public ActionResult Register()
        {
            UserData userData = new UserData();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Profil").Result;

            List<Profil> results = new List<Profil>();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<List<Profil>>(response.Content.ReadAsStringAsync().Result);
            }
            userData.Profils = results;

            return View(userData);
        }

        [HttpPost]
        public ActionResult Register(UserData user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                HashPassword = user.Password,
                Id_profil = user.Id_profil,
            };

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49455/Api/");
                string JsonString = JsonConvert.SerializeObject(newUser);
                StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("User/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                   return RedirectToAction("index", "booking");
                }

                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "User");
        }

        private void WriteLogs(string v)
        {
            throw new NotImplementedException();
        }
    }
}