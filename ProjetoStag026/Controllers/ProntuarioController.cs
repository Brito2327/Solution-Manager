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

        public ActionResult Cadastrar(String nomePaciente, String Hpp,String Hf,
            String Historia,String Obs,IList<String> lista)
        {
            
            Componente_PacienteDao com = new Componente_PacienteDao();
            ProntuarioDao pro = new ProntuarioDao();
            PacienteDao dao = new PacienteDao();
            ComponenteDao co = new ComponenteDao();
            HistoriaPatologicaPregressaDao his = new HistoriaPatologicaPregressaDao();
            HistoriaPatologicaPregressa h = new HistoriaPatologicaPregressa();
            h.HF = Hf;
            h.HistoriaSocial = Historia;
            h.HPP = Hpp;

            Prontuario prontuario = new Prontuario();
            prontuario.Observacoes = Obs;
            
            foreach (var item in dao.Select())
            {
                if (item.Nome == nomePaciente)
                {
                    prontuario.PacienteId = item.ID;
                }
            }

            if (lista != null)
            {
                foreach (var item in co.Select())
                {
                    foreach (var compi in lista)
                    {
                        if (item.Nome == compi)
                        {
                            Componente_Paciente comp = new Componente_Paciente();
                            comp.ComponenteId = item.ID;
                            comp.PacienteId = prontuario.PacienteId;
                            com.Cadastrar(comp);
                        }
                    }

                }
            }
            
            his.Cadastrar(h);
            prontuario.HistoriaPatologicaPregressaId = h.ID;
            string valida= pro.Cadastrar(prontuario)? "Sim" : "Não";

            return Json(valida);
        }

        public ActionResult Update(int idProntuario, String nomePaciente, String nomeComponente, String HPP,
            String HF, String HistoriaSocial, String observacao)
        {


            Componente_PacienteDao com = new Componente_PacienteDao();
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
                        Componente_Paciente comp = new Componente_Paciente();
                        comp.ComponenteId = item.ID;
                        comp.PacienteId = prontuario.PacienteId;
                        com.Cadastrar(comp);
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
            Componente_PacienteDao com = new Componente_PacienteDao();
            ProntuarioDao dao = new ProntuarioDao();
            Prontuario prontuario = dao.BuscaPorId(id);
            HistoriaPatologicaPregressaDao h = new HistoriaPatologicaPregressaDao();
            ComponenteDao co = new ComponenteDao();
            PacienteDao paci = new PacienteDao();
            Paciente paciente = paci.BuscaPorId(prontuario.PacienteId);

            HistoriaPatologicaPregressa historia = h.BuscaPorId(prontuario.HistoriaPatologicaPregressaId);
            
            IList<Componente> lista_componente = new List<Componente>();

            IList<Componente_Paciente> comPaci = com.BuscarAgendamentos(paciente.ID);
            if (comPaci != null)
            {
                IList<Componente_Paciente> lista = com.BuscarAgendamentos(paciente.ID);
                foreach (var item in lista)
                {
                    Componente componente = co.BuscaPorId(item.ComponenteId);
                    lista_componente.Add(componente);
                }
                ViewBag.Componente = lista_componente;
            }
            else
            {
                ViewBag.Componente = null;
            }


            ViewBag.Historia = historia;
            ViewBag.Prontuario = prontuario;
            ViewBag.Paciente = paciente;

            return View();
        }

       
    }
}