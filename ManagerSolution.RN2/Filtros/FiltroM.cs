using System.Web.Mvc;
using System.Web.Routing;


namespace ManagerSolution.RN.Filtros
{
    public class FiltroM : ActionFilterAttribute
    {
       
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                object sessaoM = filterContext.HttpContext.Session["Medico"];

                if (sessaoM == null)
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