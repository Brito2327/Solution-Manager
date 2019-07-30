using ProjetoStag026.DAO;
using ProjetoStag026.Models;
using System;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autentica(String login, String Senha)
        {
            if (login == null || Senha == null) { return RedirectToAction("Index"); }
            else
            {

                UsuarioDao dao = new UsuarioDao();
                Usuario usuario = dao.Busca(login, Senha);
                CategoriasDAO cat = new CategoriasDAO();
                Categoria categoria = cat.BuscaPorId(usuario.CategoriaId);

                if (usuario != null && categoria.Paciente == true)
                {
                    PacienteDao paci = new PacienteDao();
                    Paciente paciente = paci.BuscaUser(usuario.ID);
                    Session["Paciente"] = paciente;
                    return RedirectToAction("Index", "Cliente");
                }
                else if (usuario != null && categoria.Medico == true)
                {
                    MedicoDao me = new MedicoDao();
                    Medico medico = me.BuscaUser(usuario.ID);
                    Session["Medico"] = medico;
                    return RedirectToAction("Index", "Home");
                }
                else if (usuario != null && categoria.Atendente == true)
                {
                    FuncionarioDao fun = new FuncionarioDao();
                    Funcionario funcionario = fun.BuscaUser(usuario.ID);

                    Session["Funcionario"] = funcionario;
                    return RedirectToAction("Dashbord", "Funcionario");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

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
