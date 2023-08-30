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
        public int ID{get;set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public string sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Naturalidade { get; set; }
        public Usuario Usuario { get; set; }
        public long UsuarioId { get; set; }
        public byte[] imagem { get; set; }


    }
}