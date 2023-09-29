using ManagerSolution.DAO;
using ManagerSolution.Enum;
using ManagerSolution.Models;
using ManagerSolution.Sevices.PessoaService;
using System;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{
    public class LoginController : Controller
    {
        public string _usuarioLogado = "loggin";

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Autentica(Usuario usuario)
        {
            var valida = "";
            try
            {
                var _usuarioService = new UsuarioService();
                usuario = _usuarioService.ValidaLogin(usuario);
                Session[_usuarioLogado] = usuario;
                var pessoa = new Pessoa().BuscaPorId(usuario.PessoaId);

                switch (pessoa.TipoFuncao)
                {
                    case EPerfil.Paciente:
                        Session["Paciente"] = new Paciente().BuscaPorPessoaId(pessoa.ID);
                        valida = "Cliente";
                        break;
                    case EPerfil.Medico:
                        Session["Medico"] = new Medico().BuscaPorPessoaId(pessoa.ID);
                        valida = "Medico";
                        break;
                    case EPerfil.Atendente:

                        break;
                    default:
                        throw new Exception("Perfil de usuario não cadastrado");
                }
            }
            catch (Exception)
            {

                valida = "error";
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
