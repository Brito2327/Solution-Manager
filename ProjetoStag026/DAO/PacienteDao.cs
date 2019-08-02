using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoStag026.DAO
{
    public class PacienteDao
    {
        public void Cadastrar(Paciente paciente)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Paciente.Add(paciente);
                contexto.SaveChanges();
            }

        }

        public IList<Paciente> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Paciente.ToList();
            }

        }
        public void Alterar(Paciente paciente)
        {
            foreach (var item in Select())
            {
                if (item.ID == paciente.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.Nome = paciente.Nome;
                        item.sexo = paciente.sexo;
                        item.data = paciente.data;
                        item.Telefone = paciente.Telefone;
                        item.Naturalidade = paciente.Naturalidade;
                        contexto.Paciente.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public bool excluir( Paciente obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Paciente.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }

        public Paciente BuscaPorId(int? id)
        {
            using (var contexto = new ConecaoContext())
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
        public Paciente BuscaUser(int UsuarioId)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Paciente.FirstOrDefault(u => u.Usuario.ID == UsuarioId );
            }
        }

        public bool VerificarExistencia(string nome,string usuario)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {
                var item = contexto.Paciente.FirstOrDefault(u => u.Nome == nome);
                var item2 = contexto.Usuario.FirstOrDefault(u => u.User == usuario);
                if (item != null && item2 != null)
                {
                    valida = true;
                }
            }
            return valida;
        }
    }

}