using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class CategoriasDAO
    {
        public void Cadastrar(Categoria categoria)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Categoria.Add(categoria);
                contexto.SaveChanges();
            }

        }

        public IList<Categoria> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Categoria.ToList();
            }

        }
        public void Alterar(Categoria categoria)
        {

            foreach (var item in Select())
            {
                if (item.Id == categoria.Id)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.Medico = categoria.Medico;
                        item.Atendente = categoria.Atendente;
                        item.Paciente = categoria.Paciente;

                        contexto.Categoria.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }
        public Categoria BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Categoria
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }



    }
}