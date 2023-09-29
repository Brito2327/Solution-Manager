using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class MedicoDao
    {

        public void Cadastrar(Medico usuario)
        {
            using (var con = new GetConexao())
            {

                con.Medico.Add(usuario);
                con.SaveChanges();
            }

        }

        public IList<Medico> Select()
        {
            using (var con = new GetConexao())
            {
                return con.Medico.ToList();
            }

        }
        public bool Alterar(Medico obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var con = new GetConexao())
                    {
                        item.nome = obj.nome;
                        item.CRM = obj.CRM;
                        item.Situacao = obj.Situacao;
                        item.AreaDeAtuacao = obj.AreaDeAtuacao;
                        con.Medico.Update(item);
                        con.SaveChanges();
                        valida = true;

                    }
                }
            }
            return valida;
        }
        public bool excluir(long Idusuario)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == Idusuario)
                {
                    using (var con = new GetConexao())
                    {
                        con.Medico.Remove(item);
                        con.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public Medico BuscaPorId(long id)
        {
            using (var con = new GetConexao())
            {
                return con.Medico
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        
    }
}