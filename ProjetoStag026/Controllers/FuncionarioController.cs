using ManagerSolution.DAO;
using ManagerSolution.Filtros;
using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{[FiltroF]
    public class FuncionarioController:Controller
    {
        public ActionResult Index()
        {
            FuncionarioDao dao = new FuncionarioDao();
            IList<Funcionario> funcionarios = dao.Select();

            ViewBag.Funcionarios = funcionarios;
            return View();
        }


        public ActionResult Cadastrar(Funcionario funcionario,Usuario usuario)
        {
            UsuarioDao us = new UsuarioDao();
            FuncionarioDao dao = new FuncionarioDao();
            CategoriasDAO cat = new CategoriasDAO();
            Categoria categoria = new Categoria();
            categoria.Atendente = true;
            cat.Cadastrar(categoria);
            usuario.Categoria = categoria.Id;
            us.Cadastrar(usuario);
            funcionario.UsuarioId = usuario.ID;

            dao.Cadastrar(funcionario);

            return RedirectToAction("Index");
        }

        public ActionResult update(Funcionario funcionario)
        {
            FuncionarioDao dao = new FuncionarioDao();
            string valida = dao.Alterar(funcionario) ? "Sim" : "nao";
            return Json(valida);
        }


        public ActionResult Excluir(int id)
        {
            FuncionarioDao dao = new FuncionarioDao();
            
            string validacao = (dao.excluir(id) ? "Sim" : "Não");
            return Json(validacao);

        }
        public ActionResult Dashbord()
        {
            AgendamentoDao dao = new AgendamentoDao();
            IList<Agendamento> lista = dao.BuscarAgendamentosPorData(DateTime.Now.Date);
            PacienteDao paDao = new PacienteDao();
            IList<Paciente> listaPacientes = new List<Paciente>();
            IList<Paciente> pacientes = paDao.Select();


            foreach (var agenda in lista)
            {
                int id = agenda.PacienteId;
                Paciente paciente = paDao.BuscaPorId(id);
                listaPacientes.Add(paciente);
            }

            listaPacientes.Count();
            ViewBag.Paciente = listaPacientes;
            ViewBag.Pacientes = pacientes;
            ViewBag.Agendamento = lista;

           
            return View();
        }
    }
}