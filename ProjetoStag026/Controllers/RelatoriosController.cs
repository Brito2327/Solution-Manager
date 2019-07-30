using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Rotativa;
using Rotativa.Options;
using System.Web.Mvc;
using ProjetoStag026.DAO;
using ProjetoStag026.Models;
using ProjetoStag026.Filtros;

namespace ProjetoStag026.Controllers
{[FiltroF]
    public class RelatoriosController:Controller
    {
        public ActionResult GerarRelatorio()
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
                    if (item.MedicoId == medico.ID)
                    {
                        medicos.Add(medico.nome);
                    }
                }
            }

            foreach (var item in at.Select())
            {
                foreach (var paciente in dao.Select())
                {
                    if (item.PacienteId == paciente.ID)
                    {
                        pacientes.Add(paciente.Nome);
                    }
                }
            }

            ViewBag.Quantidade = atendimentos.Count;
            ViewBag.Atendiemtos = atendimentos;
            ViewBag.Pacientes = pacientes;
            ViewBag.Medico = medicos;

                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "Relatorio",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = atendimentos.ToPagedList(paginaNumero, atendimentos.Count)
                };
                
            return pdf;
        }
    }
}