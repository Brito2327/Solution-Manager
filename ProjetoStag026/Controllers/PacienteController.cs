using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{
    [FiltroFuncionarioMedico]
    public class PacienteController : Controller
    {
        public ActionResult Index()
        {
            PacienteDao dao = new PacienteDao();
            IList<Paciente> lista = dao.Select();
            ViewBag.Paciente = lista;
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Paciente = new Paciente();
            ViewBag.Endereco = new Endereco();
            ViewBag.Usuario = new Usuario();


            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Paciente paciente, Endereco endereco, Usuario usuario, Categoria categoria, HttpPostedFileBase upImagem)
        {
            //iniciando instacia
            PacienteDao pa = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();
            CategoriasDAO cat = new CategoriasDAO();

            //adicionando o id
            categoria.Paciente = true;
            cat.Cadastrar(categoria);
            usuario.CategoriaId = categoria.Id;
            us.Cadastrar(usuario);
            end.Cadastrar(endereco);
            if (upImagem == null)
            {
                paciente.imagem = new byte[0];
            }
            else
            {

                paciente.imagem = new byte[upImagem.ContentLength];
                upImagem.InputStream.Read(paciente.imagem, 0, upImagem.ContentLength);
            }


            //*-------------*
            paciente.EnderecoId = endereco.ID;
            paciente.UsuarioId = usuario.ID;

            //Aplicando à instancia
            pa.Cadastrar(paciente);
            return RedirectToAction("Index");
        }

        public ActionResult Paciente(int id)
        {
            PacienteDao dao = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();
            CategoriasDAO cat = new CategoriasDAO();





            Paciente paciente = dao.BuscaPorId(id);
            Endereco endereco = end.BuscaPorId(paciente.EnderecoId);
            Usuario usuario = us.BuscaPorId(paciente.UsuarioId);
            Categoria categoria = cat.BuscaPorId(usuario.CategoriaId);

            String tipo = "";
            if (categoria.Medico == true)
            {
                tipo += " Medico ";
            }
            else if (categoria.Paciente == true)
            {
                tipo += " Paciente ";
            }
            else if (categoria.Atendente == true)
            {
                tipo += " Funcionario ";
            }

            ViewBag.Paciente = paciente;
            ViewBag.Endereco = endereco;
            ViewBag.Usuario = usuario;
            ViewBag.Mensagem = tipo;

            return View();
        }

      

        public ActionResult Update(Paciente paciente, Endereco endereco)
        {
            PacienteDao dao = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();
            CategoriasDAO cat = new CategoriasDAO();

            
           
            end.Alterar(endereco);
            dao.Alterar(paciente);

            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int id)
        {
            PacienteDao dao = new PacienteDao();
            Paciente paciente = dao.BuscaPorId(id);

            string validacao = (dao.excluir(paciente) ? "Sim" : "Não");
            return Json(validacao);


        }
        public ActionResult verificarExistente(string nome, string user)
        {
            PacienteDao dao = new PacienteDao();
            string valida = (dao.VerificarExistencia(nome, user) ? "Sim" : "Não");
            return Json(valida);
        }

    }
}