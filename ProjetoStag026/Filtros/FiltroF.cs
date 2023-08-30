using System.Web.Mvc;
using System.Web.Routing;


namespace ManagerSolution.Filtros
{
    public class FiltroF : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object sessaoF = filterContext.HttpContext.Session["Funcionario"];

            if (sessaoF == null)
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