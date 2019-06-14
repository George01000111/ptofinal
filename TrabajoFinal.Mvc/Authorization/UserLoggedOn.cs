
using Restaurante.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Mvc.Constantes;

namespace TrabajoFinal.Mvc.Authorization
{

    public class UserLoggedOn: AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[SessionName.User] == null)
            {
                httpContext.Session["ShowLoginMessage"] = "Logueate primero  >:V";
                return false;
            }
            else {
                return true;
                //return base.AuthorizeCore(httpContext);
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.HttpContext.Response.Redirect("/IniciarSesion/Index");
            //base.HandleUnauthorizedRequest(filterContext);
        }

    }
}