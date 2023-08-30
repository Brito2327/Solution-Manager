using ManagerSolution.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace ManagerSolution.DAO
{
    public class UsuarioDao
    {

        public void Cadastrar(Usuario usuario)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Usuario.Add(usuario);
                contexto.SaveChanges();
            }

        }

        public IList<Usuario> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Usuario.ToList();
            }

        }
        public void Alterar(Usuario obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.User = obj.User;
                        item.Password = obj.Password;
                        contexto.Usuario.Update(item);
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
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Usuario.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }
        public Usuario BuscaPorId(long id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Usuario
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public  Usuario Busca(string login, string senha)
        {
            


            using (var contexto = new ConecaoContext())
            {

                return contexto.Usuario.FirstOrDefault(u => u.User == login && u.Password == senha);
            }
        }
    }
}