using ManagerSolution.DAO;
using ManagerSolution.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Pessoa", Schema = "sm-local")]
    public class Pessoa
    {
        public Pessoa() { }


        public long ID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Sexo {  get; set; }
        public EPerfil TipoFuncao { get; set; }
        public string Naturalidade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
       
        public byte[] imagem { get; set; }


        public void Salvar(Pessoa Pessoa)
        {
            using (var con = new GetConexao())
            {
                con.Pessoa.Add(Pessoa);
                con.SaveChanges();

            }
        }

        public IList<Pessoa> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Pessoa.ToList();
            }

        }
        public void Alterar(Pessoa Pessoa)
        {
            using (var contexto = new GetConexao())
            {
                contexto.Pessoa.Update(Pessoa);
                contexto.SaveChanges();
            }

        }
        public void excluir(Pessoa Pessoa)
        {
            using (var con = new GetConexao())
            {
                con.Pessoa.Remove(con.Pessoa.Where(p => p.ID == Pessoa.ID).FirstOrDefault());
                con.SaveChanges();                
            }
        }

        public Pessoa BuscaPorId(long? id)
        {
            using (var con = new GetConexao())
            {
                var pessoa = con.Pessoa
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
                return pessoa;
            }
           
        }       
        

        //public bool VerificarExistencia(string nome, string usuario)
        //{
        //    bool valida = false;
        //    using (var contexto = new GetConexao())
        //    {
        //        var item = contexto.Pessoa.FirstOrDefault(u => u.Nome == nome);
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