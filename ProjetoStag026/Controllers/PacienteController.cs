using ManagerSolution.DAO;
using ManagerSolution.Filtros;
using ManagerSolution.Models;
using ManagerSolution.Sevices.PessoaService;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
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
        public ActionResult Cadastrar(Paciente paciente, Endereco endereco, Usuario usuario, HttpPostedFileBase Imagem)
        {
            try
            {
                var pessoaService = new PessoaService();
                pessoaService.Cadastrar(paciente, endereco, usuario, Imagem);
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
           
            return RedirectToAction("Index");

        }

        public ActionResult Paciente(int id)
        {
            PacienteDao dao = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();
  

            Paciente paciente = dao.BuscaPorId(id);
           // Endereco endereco = end.BuscaPorId(paciente.EnderecoId);
            
            //Categoria categoria = cat.BuscaPorId(usuario.Categoria);

            //String tipo = "";
            //if (categoria.Medico == true)
            //{
            //    tipo += " Medico ";
            //}
            //else if (categoria.Paciente == true)
            //{
            //    tipo += " Paciente ";
            //}
            //else if (categoria.Atendente == true)
            //{
            //    tipo += " Funcionario ";
            //}

            //ViewBag.Paciente = paciente;
            //ViewBag.Endereco = endereco;
            //ViewBag.Usuario = usuario;
            //ViewBag.Mensagem = tipo;

            return View();
        }



        public ActionResult Update(Paciente paciente, Endereco endereco)
        {
            PacienteDao dao = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();
           



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
        //public ActionResult verificarExistente(string nome, string user)
        //{
        //    PacienteDao dao = new PacienteDao();
        //    string valida = (dao.VerificarExistencia(nome, user) ? "Sim" : "Não");
        //    return Json(valida);
        //}

    }
}