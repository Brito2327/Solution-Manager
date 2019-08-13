using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.DAO
{
    public class AgendamentoDao
    {
        public bool Cadastrar(Agendamento consulta)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {

                contexto.Agendamento.Add(consulta);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        internal IList<Agendamento> BuscarAgendamentos(string Data)
        {
            DateTime date = Convert.ToDateTime(Data);
            using (var contexto = new ConecaoContext())
            {
                return contexto.Agendamento.Where(p => p.data == date).ToList();

            }
        }

        public IList<Agendamento> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Agendamento.ToList();
            }

        }
        public void Alterar(Agendamento obj)
        {
            foreach (var item in Select())
            {
                if (item.Id == obj.Id)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.PacienteId = obj.PacienteId;
                        item.data = obj.data;
                        item.hora = obj.hora;
                        item.observacao = obj.observacao;

                        contexto.Agendamento.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public bool excluir(Agendamento obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.Id == obj.Id)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Agendamento.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }

        public Agendamento BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Agendamento
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public bool excluirPorId(int agendamentoId)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.Id == agendamentoId)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Agendamento.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }

        public IList<Agendamento> BuscarAgendamentos(DateTime Data,Medico medico)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Agendamento.Where(p => p.data == Data && p.MedicoId==medico.ID).ToList();

            }
        }

        public IList<Agendamento> BuscarAgendamentosPorData(DateTime Data)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Agendamento.Where(p => p.data == Data).ToList();

            }
        }
    }
}