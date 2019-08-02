using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Paciente
    {
        public int ID{get;set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public string sexo { get; set; }
        public DateTime data { get; set; }
        public string Telefone { get; set; }
        public string Naturalidade { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public byte[] imagem { get; set; }


    }
}