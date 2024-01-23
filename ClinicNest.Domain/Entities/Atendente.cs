using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{

    [Table("Atendente", Schema = "sm-local")]
    public class Atendente
    {
        public int ID { get; set; }
        public string Nome { get; set; }        
        public int UsuarioId { get; set; }
    }
}