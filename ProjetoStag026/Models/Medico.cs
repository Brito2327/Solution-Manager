using ManagerSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Medico", Schema = "sm-local")]
    public class Medico
    {
        public long ID { get; set; }
        public string nome { get; set; }
        public String CRM { get; set; }
        public string Situacao { get; set; }
        public string AreaDeAtuacao { get; set; }

        public long PessoaId { get; set; }





        public void Salvar(Medico usuario)
        {
            using (var con = new GetConexao())
            {
                con.Medico.Add(usuario);
                con.SaveChanges();
            }
        }

        public IList<Medico> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Medico.ToList();
            }
        }
        public void Alterar(Medico medico)
        {
            using (var con = new GetConexao())
            {
                con.Medico.Update(medico);
                con.SaveChanges();
            }
        }
        public void excluir(Medico medico)
        {
            using (var con = new GetConexao())
            {
                con.Medico.Remove(con.Medico.Where(m => m.ID == medico.ID).FirstOrDefault());
                con.SaveChanges();
            }
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
        public Medico BuscaPorPessoaId(long id)
        {
            using (var con = new GetConexao())
            {
                return con.Medico
                    .Where(p => p.PessoaId == id)
                    .FirstOrDefault();
            }
        }

    }
}