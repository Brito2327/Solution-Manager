using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class FuncionarioDao
    {
        public void Cadastrar(Funcionario obj)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Funcionario.Add(obj);
                contexto.SaveChanges();
            }

        }

        public IList<Funcionario> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Funcionario.ToList();
            }

        }
        public bool Alterar(Funcionario obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.Nome = obj.Nome;
                        contexto.Funcionario.Update(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public bool excluir(int idFuncionario)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == idFuncionario)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Funcionario.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public Funcionario BuscaPorId(int? id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Funcionario
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
        public Funcionario BuscaUser(long UsuarioId)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Funcionario.FirstOrDefault(u => u.Usuario.ID == UsuarioId);
            }
        }
    }
}