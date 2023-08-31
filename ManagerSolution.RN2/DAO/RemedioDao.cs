using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.DAO
{
    public class RemedioDao
    {
        public void Cadastrar(Remedio remedio)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Remedio.Add(remedio);
                contexto.SaveChanges();
            }

        }

        public IList<Remedio> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Remedio.ToList();
            }

        }
        public void Alterar( int Idremedio, String nome)
        {
            foreach (var item in Select())
            {
                if (item.ID == Idremedio)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.Nome = nome;
                        contexto.Remedio.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(int Idremedio)
        {
            foreach (var item in Select())
            {
                if (item.ID == Idremedio)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Remedio.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }
        public Remedio BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Remedio
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
    }
}