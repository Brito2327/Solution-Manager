using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{[FiltroF]
    public class ComponenteController : Controller
    {
        public ActionResult Index()
        {
            ComponenteDao dao = new ComponenteDao();
            IList<Componente> componentes = dao.Select();

            ViewBag.Componentes = componentes;
            return View();
        }


        public ActionResult Cadastrar(Componente componente)
        {

            if (componente != null)
            {
                ComponenteDao dao = new ComponenteDao();
                dao.Cadastrar(componente);
            }
            return RedirectToAction("Index");
        }

        public ActionResult update(int id,string Nome)
        {
            ComponenteDao dao = new ComponenteDao();
            Componente componente = new Componente();
            componente.Nome = Nome;
            foreach (var item in dao.Select())
            {
                if (item.ID==id)
                {
                    componente.ID = item.ID;
                }
            }
            string valida = dao.Alterar(componente) ? "Sim" : "nao";
            return Json(valida);
        }


        public ActionResult Excluir(int id)
        {
            ComponenteDao dao = new ComponenteDao();
            Componente componente = dao.BuscaPorId(id);

            string validacao = (dao.excluir(componente.ID) ? "Sim" : "Não");
            return Json(validacao);

        }
    }
}