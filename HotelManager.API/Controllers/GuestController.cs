using HotelManager.DAL.Entity;
using HotelManager.DAL.Interface;
using HotelManager.DAL.Repository;
using HotelManager.API.Models;
using HotelManager.API.Util.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HotelManager.API.Controllers
{
    public class GuestController : ApiController
    {
        [AcceptVerbs("GET")]
        public IEnumerable<Models.Guest> AllGuest()
        {
            return UnitOfWork.Instance.GuestRepository.GetAll().Select(x => x.ToClient()).ToList();
        }


    }
}
