using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Filtros;
using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ManagerSolution.RN.Controllers
{[FiltroF]
    public class ComponenteController : Controller
    {
        public ActionResult Index()
        {
            ConsumindoApiDao dao = new ConsumindoApiDao();
            IList<Remedio> lista_remedios = dao.Consumir();

            if (lista_remedios == null)
            {
                return HttpNotFound();
            }
            else {
                ViewBag.Remedios = lista_remedios;
                return View();
            }

           
        }
        public ActionResult Referencias(string Componente)
        {
            IList<Remedio> lista_referencias = new List<Remedio>();
            ConsumindoApiDao dao = new ConsumindoApiDao();
            
            foreach (var item in dao.Consumir())
            {
                string comp =Componente.Replace(" ", "");
                comp = comp.Replace("+", "");
               string intermediario =item.PrincipioAtivo.Replace(" ", "");
                intermediario = intermediario.Replace("+", "");
                if (intermediario == comp)
                {
                    lista_referencias.Add(item);
                }
                
            }

            ViewBag.Referencias = lista_referencias;

            return View();
        }
    }

    //    public ActionResult Cadastrar(Componente componente)
    //    {

    //        if (componente != null)
    //        {
    //            ComponenteDao dao = new ComponenteDao();
    //            dao.Cadastrar(componente);
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    public ActionResult update(int id,string Nome)
    //    {
    //        ComponenteDao dao = new ComponenteDao();
    //        Componente componente = new Componente();
    //        componente.Nome = Nome;
    //        foreach (var item in dao.Select())
    //        {
    //            if (item.ID==id)
    //            {
    //                componente.ID = item.ID;
    //            }
    //        }
    //        string valida = dao.Alterar(componente) ? "Sim" : "nao";
    //        return Json(valida);
    //    }


    //    public ActionResult Excluir(int id)
    //    {
    //        ComponenteDao dao = new ComponenteDao();
    //        Componente componente = dao.BuscaPorId(id);

    //        string validacao = (dao.excluir(componente.ID) ? "Sim" : "Não");
    //        return Json(validacao);

    //    }

}