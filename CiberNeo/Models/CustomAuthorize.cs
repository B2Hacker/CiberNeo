using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CiberNeo.Models

{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string Users { get; set; }

        private string accion = "Index";
        private string control = "Login";

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Usuario"] == null)
                return false;
            else if (Users != null && Users != string.Empty)
            {
                Usuario userLogged = (Usuario)httpContext.Session["Usuario"];
                string[] us = Users.Split(',');
                foreach (string u in us)
                {
                    if (u == userLogged.IdPerfil.ToString())
                        return true;
                }
            }
            accion = "Restringido";
            control = "Home";
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary(
                new
                {
                    controller = control,
                    action = accion
                })
            );
        }
    }
}