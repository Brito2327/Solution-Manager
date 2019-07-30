using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{
    public class ProntuarioController : Controller
    {
        [FiltroM]
        public ActionResult Index()
        {
            ProntuarioDao ag = new ProntuarioDao();
            IList<Prontuario> lista = ag.Select();
            PacienteDao dao = new PacienteDao();
            IList<Paciente> listaPacientes = new List<Paciente>();
            IList<Paciente> pacientes = dao.Select();


            foreach (var agenda in lista)
            {
                int? id = agenda.PacienteId;
                Paciente paciente = dao.BuscaPorId(id);
                listaPacientes.Add(paciente);
            }

            listaPacientes.Count();
            ViewBag.Paciente = listaPacientes;
            ViewBag.Pacientes = pacientes;
            ViewBag.Prontuario = lista;
            return View();
        }
        public ActionResult Form()
        {
            PacienteDao pa = new PacienteDao();
            IList<Paciente> listaPaciente = pa.Select();

            ComponenteDao co = new ComponenteDao();
            IList<Componente> listaComponente = co.Select();


            ViewBag.Pacientes = listaPaciente;
            ViewBag.Componentes = listaComponente;
            return View();
        }

        public ActionResult Cadastrar(String nomePaciente, Prontuario prontuario,
            HistoriaPatologicaPregressa historia, String nomeComponente)
        {
            ProntuarioDao pro = new ProntuarioDao();
            PacienteDao dao = new PacienteDao();
            ComponenteDao co = new ComponenteDao();
            HistoriaPatologicaPregressaDao his = new HistoriaPatologicaPregressaDao();

            if (nomeComponente != null)
            {
                foreach (var item in co.Select())
                {
                    if (item.Nome == nomeComponente)
                    {
                        historia.ComponenteId = item.ID;
                    }
                }
            }
            his.Cadastrar(historia);
            foreach (var item in dao.Select())
            {
                if (item.Nome == nomePaciente)
                {
                    prontuario.PacienteId = item.ID;
                }
            }
            prontuario.HistoriaPatologicaPregressaId = historia.ID;
            pro.Cadastrar(prontuario);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int idProntuario, String nomePaciente, String nomeComponente, String HPP,
            String HF, String HistoriaSocial, String observacao)
        {



            ProntuarioDao pro = new ProntuarioDao();
            PacienteDao dao = new PacienteDao();
            ComponenteDao co = new ComponenteDao();
            HistoriaPatologicaPregressaDao his = new HistoriaPatologicaPregressaDao();

            Prontuario prontuario = pro.BuscaPorId(idProntuario);
            prontuario.Observacoes = observacao;

            HistoriaPatologicaPregressa historia = his.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            historia.HPP = HPP;
            historia.HF = HF;
            historia.HistoriaSocial = HistoriaSocial;

            if (nomeComponente != null)
            {
                foreach (var item in co.Select())
                {
                    if (item.Nome == nomeComponente)
                    {
                        historia.ComponenteId = item.ID;
                    }
                }
            }


            foreach (var item in dao.Select())
            {
                if (item.Nome == nomePaciente)
                {
                    prontuario.PacienteId = item.ID;
                }
            }


            his.Alterar(historia);
            pro.Alterar(prontuario);
            string validacao = (pro.Alterar(prontuario) ? "Sim" : "Não");
            return Json(validacao);
        }

        public ActionResult Excluir(int id)
        {
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorId(id);

            string validacao = (dao.excluir(prontuario) ? "Sim" : "Não");
            return Json(validacao);
        }
        public ActionResult Prontuario(int id)
        {
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorId(id);
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            ComponenteDao co = new ComponenteDao();
            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(prontuario.PacienteId);

            HistoriaPatologicaPregressa historia = h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            string nomeComponente = "";

            if (historia.ComponenteId != null)
            {
                Componente componente = co.BuscaPorId(historia.ComponenteId);

                nomeComponente= componente.Nome;
            }
            else
            {
                nomeComponente = "Nao possui alergia";
            }
            ViewBag.Componente = nomeComponente;
            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;

            return View();
        }
    }
}