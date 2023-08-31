using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.DAO
{
    public class MedicoDao
    {

        public void Cadastrar(Medico usuario)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Medico.Add(usuario);
                contexto.SaveChanges();
            }

        }

        public IList<Medico> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Medico.ToList();
            }

        }
        public bool Alterar(Medico obj)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.nome = obj.nome;
                        item.CRM = obj.CRM;
                        item.Situacao = obj.Situacao;
                        item.AreaDeAtuacao = obj.AreaDeAtuacao;
                        contexto.Medico.Update(item);
                        contexto.SaveChanges();
                        valida = true;

                    }
                }
            }
            return valida;
        }
        public bool excluir(int Idusuario)
        {
            bool valida = false;
            foreach (var item in Select())
            {
                if (item.ID == Idusuario)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Medico.Remove(item);
                        contexto.SaveChanges();
                        valida = true;
                    }
                }
            }
            return valida;
        }
        public Medico BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Medico
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public Medico BuscaUser(long UsuarioId)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Medico.FirstOrDefault(u => u.Usuario.ID == UsuarioId);
            }
        }
    }
}