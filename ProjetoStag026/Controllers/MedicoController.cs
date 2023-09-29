using ManagerSolution.DAO;
using ManagerSolution.Filtros;
using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{
    [FiltroF]
    public class MedicoController:Controller
    {
        public ActionResult Index()
        {
            MedicoDao me = new MedicoDao();
            IList<Medico> lista = me.Select();
            ViewBag.Medicos = lista;
            return View();
        }

        public ActionResult Form()
        {

            MedicoDao me = new MedicoDao();
            IList<Medico> lista = me.Select();
            ViewBag.Medicos = lista;
            return View();
        }

        public ActionResult Cadastrar(Medico medico,Usuario usuario)
        {
            MedicoDao me = new MedicoDao();
            UsuarioDao dao = new UsuarioDao();
            
            dao.Cadastrar(usuario);

            //medico.UsuarioId = usuario.ID;
            me.Cadastrar(medico);
                      return RedirectToAction("Index");

        }

        public ActionResult Alterar(int id, string Nome, string CRM, string Situacao, string Area)
        {
            Medico medico = new Medico();
            MedicoDao dao = new MedicoDao();
            medico.ID = id;
            medico.nome = Nome;
            medico.CRM = CRM;
            medico.Situacao = Situacao;
            medico.AreaDeAtuacao = Area;

            string validacao = dao.Alterar(medico) ? "Sim" : "Não";
            return Json(validacao);

        }

        public ActionResult Medico(int id)
        {

            MedicoDao dao = new MedicoDao();
            Medico medico = dao.BuscaPorId(id);

            ViewBag.Medico = medico;
            return View();
        }

        public ActionResult Excluir(int id)
        {
           MedicoDao dao = new MedicoDao();
           Medico medico = dao.BuscaPorId(id);

           string validacao = (dao.excluir(medico.ID) ? "Sim" : "Não");
           return Json(validacao);
        }

        
    }
}