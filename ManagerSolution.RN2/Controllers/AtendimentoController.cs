﻿using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Filtros;
using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerSolution.RN.Controllers
{
    [FiltroF]
    public class AtendimentoController:Controller
    {
        public ActionResult Index()
        {
            AtendimentosDao at = new AtendimentosDao();
            IList<Atendimentos> atendimentos = at.Select();

            PacienteDao dao = new PacienteDao();
            IList<string> pacientes = new List<string>();

            MedicoDao me = new MedicoDao();
            IList<string> medicos = new List<string>();
            foreach (var item in at.Select())
            {
                foreach (var medico in me.Select())
                {
                    if (item.Medico.ID ==medico.ID)
                    {
                        medicos.Add(medico.nome);
                    }
                }
            }

            foreach (var item in at.Select())
            {
                foreach (var paciente in dao.Select())
                {
                    if (item.Paciente.ID == paciente.ID)
                    {
                        pacientes.Add(paciente.Nome);
                    }
                }
            }

            ViewBag.Quantidade = atendimentos.Count;
            ViewBag.Atendiemtos = atendimentos;
            ViewBag.Pacientes = pacientes;
            ViewBag.Medico = medicos;
            return View();
        }
    }
}