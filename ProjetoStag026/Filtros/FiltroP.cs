﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ManagerSolution.Filtros
{
    public class FiltroP : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object sessaoP = filterContext.HttpContext.Session["Paciente"];
            
            if (sessaoP == null )
            {

                filterContext.Result = new RedirectToRouteResult(
              new RouteValueDictionary(
                  new { controller = "Login", Action = "Index" }
                  )
               );
            }

        }
    }
}