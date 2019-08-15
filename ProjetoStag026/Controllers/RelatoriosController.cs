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
{
    public class RelatoriosController:Controller
    {
        [FiltroF]
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
      
        public ActionResult ClienteProntuario()
        {
            Paciente paciente = (Paciente)Session["Paciente"];

            Componente_PacienteDao com = new Componente_PacienteDao();
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorProntuario(paciente.ID);
            


            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            ComponenteDao co = new ComponenteDao();
            PacienteDao paci = new PacienteDao();
         

            HistoriaPatologicaPregressa historia = h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);

            IList<Componente> lista_componente = new List<Componente>();

            IList<Componente_Paciente> comPaci = com.BuscarAgendamentos(paciente.ID);
            if (comPaci != null)
            {
             
                string nomes = "";
                IList<Componente_Paciente> lista = com.BuscarAgendamentos(paciente.ID);

                foreach (var item in lista)
                {
                    nomes += item.Componente + ",";
                }
                    
                ViewBag.Componente = nomes;
            }
            else
            {
                ViewBag.Componente = "Nenhum Componente alergico";
            }


            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;


            

            var pdf = new ViewAsPdf
            {
                ViewName = "ClienteProntuario",
                PageSize = Size.A4,
                IsGrayScale = true
            };

            return pdf;
        }
        public ActionResult ConsultaCliente(int idConsulta)
        {
            ConsultaDao dao = new ConsultaDao();
            Consulta consulta = dao.BuscaPorId(idConsulta);
            PacienteDao paci = new PacienteDao();

            MedicoDao me = new MedicoDao();
            Medico medico = me.BuscaPorId(consulta.MedicoId);

            AnamneseDao ana = new AnamneseDao();
            Anamnese anamnese = ana.BuscaPorId(consulta.AnamneseId);

            ViewBag.Paciente = paci.BuscaPorId(consulta.PacienteId);
            ViewBag.Anamnese = anamnese;
            ViewBag.Consulta = consulta;
            ViewBag.Medico = medico;




            var pdf = new ViewAsPdf
            {
                ViewName = "ConsultaCliente",
                PageSize = Size.A4,
                IsGrayScale = true
            };

            return pdf;
        }
    }
}