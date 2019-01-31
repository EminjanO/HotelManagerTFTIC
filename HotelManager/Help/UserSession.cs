using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Help
{
    public static class UserSession
    {

        public static User CurrentUser
        {
            get { return (User)HttpContext.Current.Session["CurrentUser"]; }
            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }
    }
}