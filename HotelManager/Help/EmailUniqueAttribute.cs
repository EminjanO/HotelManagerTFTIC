using HotelManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;

namespace HotelManager.Help
{
    public class EmailUniqueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("User").Result;

            List<User> results = new List<User>();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            }

            bool retour = false;


            var v = results.FirstOrDefault(e => e.Email.Trim().Equals(value.ToString()));
            if (v==null)
            {
                retour = true;
            }

            ErrorMessage = "Email existe deja";
            return retour;
        }

    }
}