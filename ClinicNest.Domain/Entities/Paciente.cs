using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Paciente", Schema = "sm-local")]
    public class Paciente : Pessoa
    {
        public Paciente(long iD, string nome, long pessoaId)
        {
            ID = iD;
            Nome = nome;
            PessoaId = pessoaId;
        }

        public long ID { get; set; }
        public string Nome { get; set; }
        public long PessoaId { get; set; }
       

       
    }
}