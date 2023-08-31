using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.DAO
{
    public class ProntuarioDao
    {


        public bool Cadastrar(Prontuario obj)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {

                contexto.Prontuario.Add(obj);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        public IList<Prontuario> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Prontuario.ToList();
            }

        }
        public bool Alterar(Prontuario obj)
        {
            bool valida = false; 

            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                       
                        
                        item.Observacoes = obj.Observacoes;
                        contexto.Prontuario.Update(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public bool excluir(Prontuario obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Prontuario.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public Prontuario BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Prontuario
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
        public Prontuario BuscaPorProntuario(int pacienteId)
        {
            using (var contexto = new ConecaoContext())
            {
                //IList<Consulta> x = contexto.Consulta.Where(p => p.PacienteId == pacienteId).ToList();
                return contexto.Prontuario.FirstOrDefault(p => p.PacienteId == pacienteId);

            }
        }
    }
}