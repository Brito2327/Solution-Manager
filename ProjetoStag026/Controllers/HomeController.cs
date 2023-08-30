﻿using ManagerSolution.DAO;
using ManagerSolution.Filtros;
using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.Controllers
{[FiltroM]
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            Medico medico = (Medico)Session["Medico"];
            AgendamentoDao ag = new AgendamentoDao();
            IList<Agendamento> lista = ag.BuscarAgendamentos(DateTime.Now.Date, medico);

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
            return View();
        }


    }
}