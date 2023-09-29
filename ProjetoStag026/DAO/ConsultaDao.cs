using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class ConsultaDao
    {
        public bool Cadastrar(Consulta consulta)
        {
            bool valida = false;
            using (var contexto = new GetConexao())
            {

                contexto.Consulta.Add(consulta);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        public IList<Consulta> Select()
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Consulta.ToList();
            }

        }
        public void Alterar(Consulta consulta)
        {
            foreach (var item in Select())
            {
                if (item.ID == consulta.ID)
                {
                    using (var contexto = new GetConexao())
                    {
                        
                        
                        contexto.Consulta.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(Consulta obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new GetConexao())
                    {
                        contexto.Consulta.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }

        public Consulta BuscaPorId(int id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Consulta
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public IList<Consulta> BuscaPorPaciente(long pacienteId)
        {
            using (var contexto = new GetConexao())
            {
                //IList<Consulta> x = contexto.Consulta.Where(p => p.PacienteId == pacienteId).ToList();
                return contexto.Consulta.Where(p => p.PacienteId == pacienteId).ToList(); 

            }
        }
    }
}