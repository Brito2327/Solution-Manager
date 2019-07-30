using ProjetoStag026.DAO;
using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Index()
        {
            UsuarioDao ud = new UsuarioDao();
            IList<Usuario> users = ud.Select();

            CategoriasDAO cat = new CategoriasDAO();
            IList<Categoria> nomes = cat.Select();
         string mensagem = "";

            foreach (var usu in users)
            {
                    string tipo = "";
                foreach (var cate in nomes)
                {

                    if (usu.CategoriaId == cate.Id)
                    {
                        if (cate.Medico)
                        {
                            tipo += "Medico ";
                        }else if (cate.Paciente)
                        {
                            tipo += "Paciente ";
                        }else if (cate.Atendente)
                        {
                            tipo += "Funcionario";
                        }

                    }
                }
                mensagem += tipo;
            }


            ViewBag.Mensagem = mensagem;
            mensagem = "";
            ViewBag.Categoria = cat;
            ViewBag.Usuarios = users;
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
            ViewBag.Categoria = new Categoria();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario, string medico, string paciente, string atendente)
        {


            CategoriasDAO cate = new CategoriasDAO();
            Categoria categoria = new Categoria();
            categoria.Medico = Convert.ToBoolean(medico);
            categoria.Paciente = Convert.ToBoolean(paciente);
            categoria.Atendente = Convert.ToBoolean(atendente);
            cate.Cadastrar(categoria);



            UsuarioDao dao = new UsuarioDao();
            usuario.CategoriaId = categoria.Id;
            dao.Cadastrar(usuario);
            return RedirectToAction("Index");
        }
    }
}