using ManagerSolution.DAO;
using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Index()
        {
            UsuarioDao ud = new UsuarioDao();
            IList<Usuario> users = ud.Select();

           
         string mensagem = "";

            //foreach (var usu in users)
            //{
            //        string tipo = "";
            //    foreach (var cate in nomes)
            //    {

            //        if (usu.Categoria == cate.Id)
            //        {
            //            if (cate.Medico)
            //            {
            //                tipo += "Medico ";
            //            }else if (cate.Paciente)
            //            {
            //                tipo += "Paciente ";
            //            }else if (cate.Atendente)
            //            {
            //                tipo += "Funcionario";
            //            }

            //        }
            //    }
            //    mensagem += tipo;
            //}


            ViewBag.Mensagem = mensagem;
            mensagem = "";
           // ViewBag.Categoria = cat;
            ViewBag.Usuarios = users;
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
          
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario, string medico, string paciente, string atendente)
        {


           



            UsuarioDao dao = new UsuarioDao();
            
            dao.Cadastrar(usuario);
            return RedirectToAction("Index");
        }
    }
}