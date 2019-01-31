using HotelManager.API.Models;
using HotelManager.API.Util.Mappers;
using HotelManager.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManager.API.Controllers
{
    public class ProfilController : ApiController
    {

        [AcceptVerbs("GET")]
        public List<Profil> AllUsers()
        {
            List<Profil> Profils = UnitOfWork.Instance.ProfilRepository.GetAll().Select(x => x.ToClient()).ToList();
            return Profils;
        }

    }
}
