
using TrabajoFinal.Mvc.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante.Constantes;
using Servicios.Interfaces.Usuario.Peticiones;
//using TrabajoFinalWeb.Models;

namespace TrabajoFinal.Mvc.Authorization
{

    public class AdminsOnly : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[SessionName.User] != null)
            {
                UsuarioNuevo objUser = (UsuarioNuevo)httpContext.Session["user"];
                if (objUser.RolId.ToString().Equals(UserTypeNames.Admin.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.HttpContext.Response.Redirect("/Home/Index");
            //base.HandleUnauthorizedRequest(filterContext);
        }

    }
}