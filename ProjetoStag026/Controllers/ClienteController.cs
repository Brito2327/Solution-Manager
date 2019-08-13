using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace ProjetoStag026.Controllers
{
    [FiltroP]
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
        public ActionResult ConsultaIndividualP(int id)
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

        public ActionResult ProntuarioP()
        {
            Componente_PacienteDao com = new Componente_PacienteDao();
            Paciente paciente = (Paciente)Session["Paciente"];
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorProntuario(paciente.ID);
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            HistoriaPatologicaPregressa historia = new HistoriaPatologicaPregressa();
            historia= h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            ComponenteDao co = new ComponenteDao();




            IList<Componente> lista_componente = new List<Componente>();

            if (com.BuscarAgendamentos(paciente.ID) != null)
            {
                IList<Componente_Paciente> lista = com.BuscarAgendamentos(paciente.ID);
                foreach (var item in lista)
                {
                    Componente componente = co.BuscaPorId(item.ComponenteId);
                    lista_componente.Add(componente);
                }
            }

            ViewBag.Componente = lista_componente;
            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;

            return View();
        }
    }
}