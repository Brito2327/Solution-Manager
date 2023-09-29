using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class ComponenteDao
    {
        public void Cadastrar(Componente componente)
        {
            using (var contexto = new GetConexao())
            {

                contexto.Componente.Add(componente);
                contexto.SaveChanges();
            }

        }

        public IList<Componente> Select()
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Componente.ToList();
            }

        }
        public bool Alterar(Componente obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new GetConexao())
                    {
                        item.Nome = obj.Nome;
                        contexto.Componente.Update(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public bool excluir(int Idcomponente)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == Idcomponente)
                {
                    using (var contexto = new GetConexao())
                    {
                        contexto.Componente.Remove(item);
                        contexto.SaveChanges();
                        valida=true;
                    }
                }
            }
            return valida;
        }
        public Componente BuscaPorId(int? id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Componente
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        //public static implicit operator ComponenteDao(PacienteDao v)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}