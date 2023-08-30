using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class Componente_PacienteDao
    {
        public bool Cadastrar(Componente_Paciente obj)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {

                contexto.Componente_Paciente.Add(obj);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        internal IList<Componente_Paciente> BuscarAgendamentos(int pacienteId)
        {
          
            using (var contexto = new ConecaoContext())
            {
                return contexto.Componente_Paciente.Where(p => p.PacienteId == pacienteId).ToList();

            }
        }

        public IList<Componente_Paciente> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Componente_Paciente.ToList();
            }

        }
        public void Alterar(Componente_Paciente obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.Componente = obj.Componente;
                        item.PacienteId = obj.PacienteId;
                        contexto.Componente_Paciente.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public bool excluir(Componente_Paciente obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Componente_Paciente.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }

        public Componente_Paciente BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Componente_Paciente
                    .Where(p => p.PacienteId == id)
                    .FirstOrDefault();
            }
        }

    }
}