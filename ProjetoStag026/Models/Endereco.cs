using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerSolution.Models
{
    [Table("Endereco", Schema = "sm-local")]
    public class Endereco
    {
        public int ID { get; set; }
        public string rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }

    }
}