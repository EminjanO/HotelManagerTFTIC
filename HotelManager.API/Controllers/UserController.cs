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
    public class UserController : ApiController
    {
        [AcceptVerbs("GET")]
        public List<User> AllUsers()
        {
            List<User> users = UnitOfWork.Instance.UserRepository.GetAll().Select(x => x.ToClient()).ToList();
            return users;
        }
        [AcceptVerbs("Post")]
        public User CheckUser(string email, string pwd)
        {
            return UnitOfWork.Instance.UserRepository.CheckUser(email, pwd).ToClient();
        }
        [AcceptVerbs("GET")]
        public User GetUser(int id)
        {
            return UnitOfWork.Instance.UserRepository.Get(id).ToClient();
        }
        public bool Delete(int id)
        {
            return UnitOfWork.Instance.UserRepository.Delete(id);
            //return liste.Remove(e);
        }

        public int Post(User user)
        {
            return UnitOfWork.Instance.UserRepository.Insert(user.ToGlobal());
        }
    }
}
