using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerSolution.RN.Models
{
    [Table("Funcionario", Schema = "sm-local")]
    public class Funcionario
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public long UsuarioId { get; set; }
    }
}