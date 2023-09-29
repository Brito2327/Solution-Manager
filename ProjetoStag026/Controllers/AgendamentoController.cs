using ManagerSolution.DAO;
using ManagerSolution.Filtros;
using ManagerSolution.Models;
using ManagerSolution.Sevices.AgendamentoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{
    public class AgendamentoController : Controller
    {
        [FiltroF]
        public ActionResult Index()
        {
            MedicoDao me = new MedicoDao();
            AgendamentoDao ag = new AgendamentoDao();
            IList<Agendamento> lista = ag.Select();
            PacienteDao dao = new PacienteDao();
            IList<Paciente> listaPacientes = new List<Paciente>();
            IList<Paciente> pacientes = dao.Select();


            foreach (var agenda in lista)
            {
                var id = agenda.Paciente.ID;
                Paciente paciente = dao.BuscaPorId(id);
                listaPacientes.Add(paciente);
            }

            listaPacientes.Count();
            ViewBag.Paciente = listaPacientes;
            ViewBag.Pacientes = pacientes;
            ViewBag.Agendamento = lista;
            ViewBag.Medicos = me.Select();

            return View();
        }
        [FiltroF]
        public ActionResult Cadastrar(Agendamento agendamento)
        {
            string validacao = "Não";
            try
            {
                var _agendamentoService = new AgendamentoService();
                _agendamentoService.Cadastrar(agendamento);
                validacao = "Sim";
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);                
            }            
            
            return Json(validacao);

        }
        [FiltroF]
        public ActionResult Atualizar(Agendamento agendamento, String nomePaciente)
        {
            AgendamentoDao dao = new AgendamentoDao();
            PacienteDao paci = new PacienteDao();

            //foreach (var item in paci.Select())
            //{
            //    if (item.Nome == nomePaciente)
            //    {
            //        agendamento.PacienteId = item.ID;
            //    }
            //}
            dao.Alterar(agendamento);
            return RedirectToAction("Index");

        }
        [FiltroF]
        public ActionResult Agendamento(int id)
        {
            AgendamentoDao dao = new AgendamentoDao();
            Agendamento agendamento = dao.BuscaPorId(id);


            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(agendamento.Paciente.ID);

            MedicoDao m = new MedicoDao();
            Medico medico = m.BuscaPorId(agendamento.Medico.ID);

            ViewBag.Medico = medico;
            ViewBag.Paciente = paciente;
            ViewBag.Agendamento = agendamento;
            return View();
        }

        public ActionResult Excluir(int id)
        {
            if (Session["Medico"] != null || Session["Funcionario"] != null)
            {
                AgendamentoDao dao = new AgendamentoDao();
                Agendamento agendamento = dao.BuscaPorId(id);

                string validacao = dao.excluir(agendamento) ? "Sim" : "Não";
                return Json(validacao);
            }
            return Json("Não");
        }
       
    }
}