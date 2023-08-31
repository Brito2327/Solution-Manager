using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Enum;
using ManagerSolution.RN.Models;
using System;
using System.Web.Mvc;

namespace ManagerSolution.RN.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Autentica(String login, String Senha)
        {
            string valida = "error";

            UsuarioDao dao = new UsuarioDao();
            Usuario usuario = dao.Busca(login, Senha);
            if (usuario != null)
            {   

                if (usuario != null && (ECategoriaUsurio)usuario.Categoria == ECategoriaUsurio.Paciente)
                {
                    PacienteDao paci = new PacienteDao();
                    Paciente paciente = paci.BuscaUser(usuario.ID);
                    Session["Paciente"] = paciente;
;
                    valida = "Cliente";
                }
                else if (usuario != null && (ECategoriaUsurio)usuario.Categoria == ECategoriaUsurio.Medico)
                {
                    MedicoDao me = new MedicoDao();
                    Medico medico = me.BuscaUser(usuario.ID);
                    Session["Medico"] = medico;
                    
                    valida = "Medico";
                }
                else if (usuario != null && (ECategoriaUsurio)usuario.Categoria == ECategoriaUsurio.Atendente)
                {
                    FuncionarioDao fun = new FuncionarioDao();
                    Funcionario funcionario = fun.BuscaUser(usuario.ID);

                    Session["Funcionario"] = funcionario;
                    valida = "Funcionario";
                }
            }

            return Json(valida);
        }
        public ActionResult Sair()
        {
            Session["Funcionario"] = null;
            Session["Paciente"] = null;
            Session["Medico"] = null;

            return RedirectToAction("Index");
        }



    }
}
