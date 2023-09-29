using ManagerSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Funcionario", Schema = "sm-local")]
    public class Funcionario
    {
        public long ID { get; set; }
        public long PessoaId { get; set; }


        public void Salvar(Funcionario funcionario)
        {
            using (var con = new GetConexao())
            {
                con.Funcionario.Add(funcionario);
                con.SaveChanges();
            }
        }

        public IList<Funcionario> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Funcionario.ToList();
            }

        }
        public void Alterar(Funcionario funcionario)
        {
            using (var con = new GetConexao())
            {
                con.Funcionario.Update(funcionario);
                con.SaveChanges();
            }
        }
        public void excluir(Funcionario funcionario)
        {
            using (var con = new GetConexao())
            {
                con.Funcionario.Remove(con.Funcionario.Where(f => f.ID == funcionario.ID).FirstOrDefault());
                con.SaveChanges();
            }
        }
        public Funcionario BuscaPorId(int? id)
        {
            using (var con = new GetConexao())
            {
                return con.Funcionario
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public Funcionario BuscaPorPessoaId(int? id)
        {
            using (var con = new GetConexao())
            {
                return con.Funcionario
                    .Where(p => p.PessoaId == id)
                    .FirstOrDefault();
            }
        }



    }
}