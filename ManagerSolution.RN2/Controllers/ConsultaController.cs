using ManagerSolution.RN.DAO;
using ManagerSolution.RN.Filtros;
using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ManagerSolution.RN.Controllers
{
    public class ConsultaController : Controller
    {
        [FiltroM]
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

            PacienteDao paci = new PacienteDao();

            ViewBag.Paciente = paci.BuscaPorId(consulta.PacienteId);
            ViewBag.Anamnese = anamnese;
            ViewBag.Consulta = consulta;
            ViewBag.Medico = medico;
            return View();
        }
        [FiltroM]
        public ActionResult Form(int pacienteId, int agendamentoId)
        { AgendamentoDao ag = new AgendamentoDao();
            Agendamento agendamento = ag.BuscaPorId(agendamentoId);
            //Criando atendimento
            AtendimentosDao atend = new AtendimentosDao();
            Atendimentos atendimento = new Atendimentos();
            atendimento.data = agendamento.data;
            atendimento.Medico.ID = agendamento.MedicoId;
            atendimento.Paciente.ID = agendamento.PacienteId;
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
            Componente_PacienteDao com = new Componente_PacienteDao();
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            //ComponenteDao co = new ComponenteDao();
            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(pacienteId);

            HistoriaPatologicaPregressa historia = h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            //IList<Componente> lista_componente = new List<Componente>();
            IList<Componente_Paciente> lista= new List<Componente_Paciente>();
            if (com.BuscarAgendamentos(paciente.ID) != null)
            {
                lista = com.BuscarAgendamentos(paciente.ID);
                ViewBag.Componente = lista;
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
            
            return View();
        }
        [FiltroM]
        public ActionResult Cadastrar(string TPR,string Antecedentes,string QP,int PacienteId,
            string HDA,string EXAME,string Diagnostico,string Prescricao,int MedicoId,DateTime data)
        {
            Consulta consulta = new Consulta();
            Anamnese anamnese = new Anamnese();
            consulta.MedicoId = MedicoId;
            consulta.PacienteId = PacienteId;
            consulta.Data = data;
            anamnese.componentePrescrito = Prescricao;
            anamnese.Antecedentes = Antecedentes;
            anamnese.Diagnostico = Diagnostico;
            anamnese.ExameFisico = EXAME;
            anamnese.TPR = TPR;
            anamnese.HDA = HDA;
            anamnese.QP = QP;

            AnamneseDao ana = new AnamneseDao();
            ana.Cadastrar(anamnese);
            consulta.AnamneseId = anamnese.ID;

            ConsultaDao dao = new ConsultaDao();

            string valida = dao.Cadastrar(consulta) ? "Sim" : "Nao";
            return Json(valida);
        }
        public JsonResult remedios(int pacienteId)
        {
            Componente_PacienteDao com = new Componente_PacienteDao();
            IList<Componente_Paciente> lista = new List<Componente_Paciente>();
            if (com.BuscarAgendamentos(pacienteId) != null)
            {
                lista = com.BuscarAgendamentos(pacienteId);
                ViewBag.Componente = lista;
            }

            ConsumindoApiDao api = new ConsumindoApiDao();
            IList<Remedio> RemediosQuePaicienteNaoTemAlergia = new List<Remedio>();

            foreach (var item in api.Consumir())
            {
                foreach (var item2 in lista)
                {
                    if (!item.PrincipioAtivo.Contains(item2.Componente)&& RemediosQuePaicienteNaoTemAlergia.Count<11)
                    {
                        RemediosQuePaicienteNaoTemAlergia.Add(item);

                    }
                }
            }
            return Json(RemediosQuePaicienteNaoTemAlergia);
        }
    }
}