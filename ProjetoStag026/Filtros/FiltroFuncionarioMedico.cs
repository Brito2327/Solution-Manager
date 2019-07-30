using System.Web.Mvc;
using System.Web.Routing;


namespace ProjetoStag026.Filtros
{
    public class FiltroFuncionarioMedico : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object sessaoF = filterContext.HttpContext.Session["Funcionario"];
            object sessaoM = filterContext.HttpContext.Session["Medico"];

            if (sessaoF == null&&sessaoM==null)
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