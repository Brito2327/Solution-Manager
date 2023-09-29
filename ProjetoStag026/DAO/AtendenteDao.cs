using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class AtendenteDao
    {
        public void Cadastrar(Atendente atendente)
        {
            using (var contexto = new GetConexao())
            {

                contexto.Atendente.Add(atendente);
                contexto.SaveChanges();
            }

        }

        public IList<Atendente> Select()
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Atendente.ToList();
            }

        }
        public void Alterar(int Idusuario, String nome)
        {
            foreach (var item in Select())
            {
                if (item.ID == Idusuario)
                {
                    using (var contexto = new GetConexao())
                    {
                        item.Nome = nome;
                       
                        contexto.Atendente.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(int Idusuario)
        {
            foreach (var item in Select())
            {
                if (item.ID == Idusuario)
                {
                    using (var contexto = new GetConexao())
                    {
                        contexto.Atendente.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }
        public Atendente BuscaPorId(int id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Atendente
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
    }
}