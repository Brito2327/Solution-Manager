using ManagerSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Paciente", Schema = "sm-local")]
    public class Paciente
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public long PessoaId { get; set; }
        public byte[] imagem { get; set; }


        public void Salvar(Paciente paciente)
        {
            using (var con = new GetConexao())
            {
                con.Paciente.Add(paciente);
                con.SaveChanges();
            }
        }

        public IList<Paciente> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Paciente.ToList();
            }

        }
        public void Alterar(Paciente paciente)
        {
            using (var contexto = new GetConexao())
            {
                contexto.Paciente.Update(paciente);
                contexto.SaveChanges();
            }

        }
        public void excluir(Paciente paciente)
        {
            using (var con = new GetConexao())
            {
                con.Paciente.Remove(con.Paciente.Where(p => p.ID == paciente.ID).FirstOrDefault());
                con.SaveChanges();                
            }
        }

        public Paciente BuscaPorId(long? id)
        {
            using (var con = new GetConexao())
            {
                return con.Paciente
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
        public Paciente BuscaPorPessoaId(long? id)
        {
            using (var con = new GetConexao())
            {
                return con.Paciente
                    .Where(p => p.PessoaId == id)
                    .FirstOrDefault();
            }
        }


        //public bool VerificarExistencia(string nome, string usuario)
        //{
        //    bool valida = false;
        //    using (var contexto = new GetConexao())
        //    {
        //        var item = contexto.Paciente.FirstOrDefault(u => u.Nome == nome);
        //        var item2 = contexto.Usuario.FirstOrDefault(u => u.User == usuario);
        //        if (item != null && item2 != null)
        //        {
        //            valida = true;
        //        }
        //    }
        //    return valida;
        //}w

    }
}