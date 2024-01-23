using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Pessoa", Schema = "sm-local")]
    public class Pessoa
    {
        public Pessoa() { }
        public Pessoa(long iD, string nome, string cpf, int sexo,
            string naturalidade, DateTime? dataNascimento, string telefone, byte[] imagem)
        {
            ID = iD;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
           
            Naturalidade = naturalidade;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            this.imagem = imagem;
        }

        public long ID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Sexo {  get; set; }
        
        public string Naturalidade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
       
        public byte[] imagem { get; set; }           


    }
}