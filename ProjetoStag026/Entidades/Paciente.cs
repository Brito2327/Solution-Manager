using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Entidades
{
    public class Paciente
    {
        public int ID{get;set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }       
        public string sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Naturalidade { get; set; }
        public Usuario Usuario { get; set; }       
        public byte[] imagem { get; set; }


    }
}