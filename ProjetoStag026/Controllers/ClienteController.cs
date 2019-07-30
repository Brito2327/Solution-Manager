using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{[FiltroP]
    public class ClienteController:Controller
    {
        public ActionResult Index()
        {
            Paciente paciente = (Paciente)Session["Paciente"];
            ConsultaDao dao = new ConsultaDao();
            IList<Consulta> listaConsultas = dao.BuscaPorPaciente(paciente.ID);
            ViewBag.Consultas = listaConsultas;
            return View();
            
        }
        public ActionResult ConsultaIndividual(int id)
        {
            ConsultaDao dao = new ConsultaDao();
            Consulta consulta = dao.BuscaPorId(id);

            MedicoDao me = new MedicoDao();
            Medico medico = me.BuscaPorId(consulta.MedicoId);

            AnamneseDao ana = new AnamneseDao();
            Anamnese anamnese = ana.BuscaPorId(consulta.AnamneseId);

            ViewBag.Anamnese = anamnese;
            ViewBag.Consulta = consulta;
            ViewBag.Medico = medico;
            return View();
            
        }

        public ActionResult Prontuario()
        {
            Paciente paciente = (Paciente)Session["Paciente"];
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorId(paciente.ID);
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            HistoriaPatologicaPregressa historia = new HistoriaPatologicaPregressa();
            historia= h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            ComponenteDao co = new ComponenteDao();
            
           

          

            if (historia.ComponenteId != null)
            {
                Componente componente = co.BuscaPorId(historia.ComponenteId);

                ViewBag.Componente = componente;
            }
            else
            {
                ViewBag.Componente = "Nao Possui alergia";
            }
            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;

            return View();
        }
    }
}