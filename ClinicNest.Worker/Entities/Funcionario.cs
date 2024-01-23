namespace ClinicNest.Domain.Entities
{
    public class Funcionario:Pessoa
    {
        public long ID { get; set; }
        public long PessoaId { get; set; }       

    }
}