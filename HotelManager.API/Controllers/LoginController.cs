using HotelManager.API.Models;
using HotelManager.API.Util.Mappers;
using HotelManager.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace HotelManager.API.Controllers
{
    public class LoginController : ApiController
    {
        [AcceptVerbs("GET")]
        public List<User> AllUsers()
        {
            List<User> users = UnitOfWork.Instance.UserRepository.GetAll().Select(x => x.ToClient()).ToList();
            return users;
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
        [AcceptVerbs("Post")]
        public User Post(User u)
        {
            string email = u.Email.ToString();
            string pwd = u.HashPassword.ToString();
            return UnitOfWork.Instance.UserRepository.CheckUser(email, pwd).ToClient();
        }
    }
}
