using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
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