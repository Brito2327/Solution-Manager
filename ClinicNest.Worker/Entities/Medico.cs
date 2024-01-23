
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Medico", Schema = "sm-local")]
    public class Medico:Pessoa
    {
        public Medico(long iD, string nome, string cRM, string situacao,
            string areaDeAtuacao, long pessoaId)
        {
            ID = iD;
            this.nome = nome;
            CRM = cRM;
            Situacao = situacao;
            AreaDeAtuacao = areaDeAtuacao;
            PessoaId = pessoaId;
        }

        public long ID { get; set; }
        public string nome { get; set; }
        public String CRM { get; set; }
        public string Situacao { get; set; }
        public string AreaDeAtuacao { get; set; }

        public long PessoaId { get; set; }

    }
}