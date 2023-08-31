using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.RN.Controllers
{
    public class RemedioController:Controller
    {

        public ActionResult ConsumindoApi()
        {
            ConsumindoApiDao dao = new ConsumindoApiDao();
            IList<Remedio> lista_remedios = dao.Consumir();

            if (lista_remedios == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Remedios = lista_remedios;
                return View();
            }

           
        }

    }
}