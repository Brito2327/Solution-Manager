﻿using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Filtros;
using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ManagerSolution.Entidades;
using ManagerSolution.RN.Models;

namespace ManagerSolution.RN.Controllers
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
                int id = agenda.PacienteId;
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
        public ActionResult Cadastrar(String nomePaciente, String nomeMedico, DateTime Data, String Hora, String Observacao, String Plano)
        {
            AgendamentoDao ag = new AgendamentoDao();
            PacienteDao dao = new PacienteDao();
            MedicoDao me = new MedicoDao();


            Agendamento agendamento = new Agendamento();
            agendamento.hora = Hora;
            agendamento.data = Data;
            agendamento.observacao = Observacao;
            agendamento.Plano = Plano;
            foreach (var item in dao.Select())
            {
                if (item.Nome == nomePaciente)
                {
                    agendamento.PacienteId = item.ID;
                }
            }

            foreach (var item in me.Select())
            {
                if (item.nome == nomeMedico)
                {
                    agendamento.MedicoId = item.ID;
                }
            }

            string validacao = (ag.Cadastrar(agendamento) ? "Sim" : "Não");
            return Json(validacao);

        }
        [FiltroF]
        public ActionResult Atualizar(Agendamento agendamento, String nomePaciente)
        {
            AgendamentoDao dao = new AgendamentoDao();
            PacienteDao paci = new PacienteDao();

            foreach (var item in paci.Select())
            {
                if (item.Nome == nomePaciente)
                {
                    agendamento.PacienteId = item.ID;
                }
            }
            dao.Alterar(agendamento);
            return RedirectToAction("Index");

        }
        [FiltroF]
        public ActionResult Agendamento(int id)
        {
            AgendamentoDao dao = new AgendamentoDao();
            Agendamento agendamento = dao.BuscaPorId(id);


            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(agendamento.PacienteId);

            MedicoDao m = new MedicoDao();
            Medico medico = m.BuscaPorId(agendamento.MedicoId);

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