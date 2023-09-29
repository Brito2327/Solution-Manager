using ManagerSolution.DAO;
using ManagerSolution.Models;
using ManagerSolution.Utils;
using System;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{
    public class LoginControllerTeste : BaseController
    {

        //public ActionResult Index()
        //{
        //    //return View();

        //}
        //public ActionResult Autentica(String login, String Senha)
        //{
        //    string valida = "error";

        //    UsuarioDao dao = new UsuarioDao();
        //    Usuario usuario = dao.Busca(login, Senha);
        //    if (usuario != null)
        //    {
        //        CategoriasDAO cat = new CategoriasDAO();
        //        Categoria categoria = cat.BuscaPorId(usuario.CategoriaId);

        //        if (usuario != null && categoria.Paciente == true)
        //        {
        //            PacienteDao paci = new PacienteDao();
        //            Paciente paciente = paci.BuscaUser(usuario.ID);
        //            //  Session["Paciente"] = paciente;
        //            ;
        //            valida = "Cliente";
        //        }
        //        else if (usuario != null && categoria.Medico == true)
        //        {
        //            MedicoDao me = new MedicoDao();
        //            Medico medico = me.BuscaUser(usuario.ID);
        //            // Session["Medico"] = medico;

        //            valida = "Medico";
        //        }
        //        else if (usuario != null && categoria.Atendente == true)
        //        {
        //            FuncionarioDao fun = new FuncionarioDao();
        //            Funcionario funcionario = fun.BuscaUser(usuario.ID);

        //            //  Session["Funcionario"] = funcionario;
        //            valida = "Funcionario";
        //        }
        //    }

        //    //  return Json(valida);
        //}
        //public ActionResult Sair()
        //{
        //    //  Session["Funcionario"] = null;
        //    //  Session["Paciente"] = null;
        //    //  Session["Medico"] = null;

        //    // return RedirectToAction("Index");
        //}



    }
}
