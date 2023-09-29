using ManagerSolution.DAO;
using ManagerSolution.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Usuario", Schema = "sm-local")]
    public class Usuario
    {
        public long ID { get; set; }
        public string NomeUsuario { get; set; }
        public string Password { get; set; }        
        public ECategoriaUsurio Categoria { get; set; }
        public long PessoaId { get; set; }


        public void Salvar(Usuario usuario)
        {
            using (var con = new GetConexao())
            {
                con.Usuario.Add(usuario);
                con.SaveChanges();
            }
        }

        public IList<Usuario> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Usuario.ToList();
            }
        }
        public void Alterar(Usuario usuario)
        {

            using (var con = new GetConexao())
            {
                con.Usuario.Update(usuario);
                con.SaveChanges();
            }
        }
        public void excluir(Usuario usuario)
        {
            using (var con = new GetConexao())
            {
                con.Usuario.Remove(con.Usuario.Where(u => u.ID == usuario.ID).FirstOrDefault());
                con.SaveChanges();
            }
        }
        public Usuario BuscaPorId(long id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Usuario
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public Usuario BuscaUsuario(string login, string senha)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Usuario.FirstOrDefault(u => u.NomeUsuario == login && u.Password == senha);
            }
        }
    }
}