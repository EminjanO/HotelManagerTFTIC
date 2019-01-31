using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelManager.Help
{
    public class CustomAuthAttribute:AuthorizeAttribute
    {
        private int[] _rolesAuth;

        public CustomAuthAttribute( params int[] roles)
        {
            _rolesAuth = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (UserSession.CurrentUser == null || !_rolesAuth.Contains(UserSession.CurrentUser.Id_profil)) // TODO 
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    { "action", "Index" },
                    { "controller", "User" },
                    { "Area", string.Empty }
                });
            }
        }
    }
}