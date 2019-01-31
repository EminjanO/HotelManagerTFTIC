using HotelManager.Help;
using HotelManager.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    public class RoomController : Controller
    {
        public ActionResult Index(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Room/" + id).Result;

            RoomTypeRoomVM results = new RoomTypeRoomVM();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<RoomTypeRoomVM>(response.Content.ReadAsStringAsync().Result);
            }

            List<IListBlobItem> v = BlobStockage.GetBlobPhoto("hotelmanagerphoto");
            foreach (var i in v)
            {
                
                results.BlobLinkPhoto.Add(i.Uri.AbsoluteUri.ToString());
            }

            return View(results);
        }

        public JsonResult getJson(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49455/Api/");
            HttpResponseMessage response = client.GetAsync("Room/" + id).Result;

            RoomTypeRoomVM results = new RoomTypeRoomVM();

            if (response.IsSuccessStatusCode)
            {
                results = JsonConvert.DeserializeObject<RoomTypeRoomVM>(response.Content.ReadAsStringAsync().Result);
            }

            return new JsonResult { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}