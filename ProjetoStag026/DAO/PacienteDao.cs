using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class PacienteDao
    {
        public bool Cadastrar(Paciente paciente)
        {
            bool valida = false;
            using (var con = new GetConexao())
            {

                con.Paciente.Add(paciente);
                con.SaveChanges();
                valida = true;
            }
            return valida;
        }

        public IList<Paciente> Select()
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Paciente.ToList();
            }

        }
        public void Alterar(Paciente paciente)
        {

            using (var contexto = new GetConexao())
            {
                contexto.Paciente.Update(paciente);
                contexto.SaveChanges();
            }


        }
        public bool excluir(Paciente obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new GetConexao())
                    {
                        contexto.Paciente.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }

        public Paciente BuscaPorId(long? id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Paciente
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public static implicit operator PacienteDao(AgendamentoDao v)
        {
            throw new NotImplementedException();
        }
       

        //public bool VerificarExistencia(string nome, string usuario)
        //{
        //    bool valida = false;
        //    using (var contexto = new GetConexao())
        //    {
        //        var item = contexto.Paciente.FirstOrDefault(u => u.Nome == nome);
        //        var item2 = contexto.Usuario.FirstOrDefault(u => u.User == usuario);
        //        if (item != null && item2 != null)
        //        {
        //            valida = true;
        //        }
        //    }
        //    return valida;
        //}
    }

}