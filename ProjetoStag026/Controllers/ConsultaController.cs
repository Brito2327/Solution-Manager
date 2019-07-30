using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{[FiltroM]
    public class ConsultaController : Controller
    {
        public ActionResult Index(int pacienteid)
        {
            ConsultaDao dao = new ConsultaDao();
            IList<Consulta> listaConsultas = dao.BuscaPorPaciente(pacienteid);
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
        public ActionResult Form(int pacienteId, int agendamentoId)
        { AgendamentoDao ag = new AgendamentoDao();
            Agendamento agendamento = ag.BuscaPorId(agendamentoId);
            //Criando atendimento
            AtendimentosDao atend = new AtendimentosDao();
            Atendimentos atendimento = new Atendimentos();
            atendimento.data = agendamento.data;
            atendimento.MedicoId = agendamento.MedicoId;
            atendimento.PacienteId = agendamento.PacienteId;
            atendimento.Plano = agendamento.Plano;

            atend.Cadastrar(atendimento);


            Prontuario prontuario = new Prontuario();
            ProntuarioDao dao = new ProntuarioDao();
            
            foreach (var item in dao.Select())
            {
                if (item.PacienteId == (pacienteId))
                {
                    prontuario = item;
                }
            }
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            ComponenteDao co = new ComponenteDao();
            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(pacienteId);

            HistoriaPatologicaPregressa historia = h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            string nomeComponente = "";
            if (historia.ComponenteId != null)
            {
                Componente componente = co.BuscaPorId(historia.ComponenteId);

               nomeComponente= componente.Nome;
            }
            else
            {
               nomeComponente = "Nao Possui alergia";
            }

            ConsultaDao con = new ConsultaDao();
            IList<Consulta> listaConsultas = con.BuscaPorPaciente(pacienteId);
            MedicoDao me = new MedicoDao();
            Medico medico = me.BuscaPorId(agendamento.MedicoId);

            ViewBag.Medico = medico;
            ViewBag.Agendamento = agendamento;
            ViewBag.Consultas = listaConsultas;
            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;
            ViewBag.Componente = nomeComponente;
            return View();
        }
        public ActionResult Cadastrar(Consulta consulta,Anamnese anamnese, int agendamentoId,string nomeMedico)
        {
            AnamneseDao ana = new AnamneseDao();
            ana.Cadastrar(anamnese);
            consulta.AnamneseId = anamnese.ID;

            MedicoDao me = new MedicoDao();
            foreach (var item in me.Select())
            {
                if (item.nome==nomeMedico)
                {
                    consulta.MedicoId = item.ID;
                }

            }


            AgendamentoDao ag = new AgendamentoDao();
            ag.excluirPorId(agendamentoId);

            ConsultaDao dao = new ConsultaDao();
            dao.Cadastrar(consulta);

            return RedirectToAction("Index", "Home");
        }
    }
}